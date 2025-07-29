using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrjMiddleProject.Models;
using PrjMiddleProject.ViewModel;
using PrjMiddleProject.ViewModels;
using System.Globalization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PrjMiddleProject.Controllers
{
    public class EventController : Controller
    {
        //show EventDetail
        public IActionResult List(string txtKeyWord, int page = 1,string sortBy = "id")
        {
            int pageSize = 10;
            NursingHomeContext db = new NursingHomeContext();

            var query = db.EventDetails
               .Include(e => e.Category)
               .Include(e => e.StatusNavigation)
               .AsQueryable();
            //搜尋
            if (!string.IsNullOrEmpty(txtKeyWord))
            {
                int keywordAsInt;
                bool isInt = int.TryParse(txtKeyWord, out keywordAsInt);

                query = query.Where(e =>
                    (e.EventName != null && e.EventName.Contains(txtKeyWord)) ||
                    (e.Description != null && e.Description.Contains(txtKeyWord)) ||
                     e.EventId.ToString().Contains(txtKeyWord)
                );
            }
            ViewBag.CurrentSort = sortBy;
            switch (sortBy)
            {
                case "EventID":
                    query = query.OrderBy(e => e.EventId);
                    break;
                case "CategoryID":
                    query = query.OrderByDescending(e => e.CategoryId);
                    break;
                case "Status":
                    query = query.OrderByDescending(e => e.Status);
                    break;
                default:
                    query = query.OrderBy(e => e.EventId);
                    break;
            }
            // 分頁資料，轉為 ViewModel
            int totalCount = query.Count();
            var result = query
                 //.OrderBy(e => e.EventId)
                 .Skip((page - 1) * pageSize)
                 .Take(pageSize)
                 .Select(m => new CEventDetailViewModel
                 {
                     EventId = m.EventId,//活動編號
                     EventName = m.EventName, //活動名稱
                     Organizer = m.Organizer,//主辦單位
                     Category = m.Category,//類別
                     ContactPersonId = m.ContactPersonId,//聯繫窗口
                     EventLocation = m.EventLocation,//活動地點
                     Description = m.Description,//活動內容
                     TotalAmount = m.TotalAmount,//金額
                     StatusNavigation = m.StatusNavigation,//狀態
                 }).ToList();


            // 傳遞分頁資訊
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalCount / pageSize);


            //if(string.IsNullOrEmpty(txtKeyWord))
            //    datas=from e in db.EventDetails.Include(e => e.Category).Include(e => e.StatusNavigation)
            //          select e;
            //else
            //    datas= db.EventDetails.Include(e => e.Category).Where(e => e.EventName.Contains(txtKeyWord));

            //抓取聯繫窗口人員姓名(資料庫忘記串接)
            var employeeDict = db.Employees.ToDictionary(e => e.EmployeeId, e => e.Name);
            ViewBag.EmployeeDict = employeeDict;
            
            
            return View(result);
        }

        //新增
        public IActionResult Create()
        {
            NursingHomeContext db = new NursingHomeContext();
            //預設資料
            //活動類型
            var categories = db.EventCategories
             .Select(c => new SelectListItem
             {
                Value = c.CategoryId.ToString(),   //下拉選單實際的值
                 Text = c.CategoryName             //下拉選單顯示的字
            }).ToList();

            ViewBag.CategoryId = categories;
            //活動狀態
            var status = db.EventStatuses.Where(e=>e.StatusCategory=="活動總表")
            .Select(c => new SelectListItem
            {
                Value = c.StatusId.ToString(),   //下拉選單實際的值
                Text = c.StatusName             //下拉選單顯示的字
            }).ToList();

            ViewBag.Status = status;
            //負責人員
            // 把所有員工撈出來，傳給 ViewBag
            var employees = db.Employees.ToList();
            ViewBag.EmployeeList = employees;



            return View();
        }
        [HttpPost]
        public IActionResult Create(EventDetail p)
        {
          
            NursingHomeContext db = new NursingHomeContext();
            //預設資料
            p.CreatedAt = DateTime.Now;
            p.CreatedBy = 20;
            if(p.TotalAmount==null)
                p.TotalAmount = 0;

            db.EventDetails.Add(p);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("List");

            NursingHomeContext db = new NursingHomeContext();
            //預設資料
            //活動類型
            var categories = db.EventCategories
             .Select(c => new SelectListItem
             {
                 Value = c.CategoryId.ToString(),   //下拉選單實際的值
                 Text = c.CategoryName             //下拉選單顯示的字
             }).ToList();

            ViewBag.CategoryId = categories;
            //活動狀態
            var status = db.EventStatuses.Where(e => e.StatusCategory == "活動總表")
            .Select(c => new SelectListItem
            {
                Value = c.StatusId.ToString(),   //下拉選單實際的值
                Text = c.StatusName             //下拉選單顯示的字
            }).ToList();
            ViewBag.Status = status;
            // 把所有員工撈出來，傳給 ViewBag
            var employees = db.Employees.ToList();
            ViewBag.EmployeeList = employees;




            EventDetail x = db.EventDetails.FirstOrDefault(p => p.EventId == id);
            if (x == null)
                return RedirectToAction("List");
            string? contactName = db.Employees
    .Where(e => e.EmployeeId == x.ContactPersonId)
    .Select(e => e.Name)
    .FirstOrDefault();

            // 轉成 ViewModel
            var viewModel = new CEventDetailViewModel
            {
                EventId = x.EventId,
                EventName = x.EventName,
                Organizer = x.Organizer,
                TargetAudience = x.TargetAudience,
                CategoryId = x.CategoryId,
                Status = x.Status,
                ContactPersonId = x.ContactPersonId,
                ContactPersonName= contactName,
                ContactPhone = x.ContactPhone,
                EventLocation = x.EventLocation,
                Quota = x.Quota,
                Description = x.Description,
                MedicalAid = x.MedicalAid,
                IsPaid = x.IsPaid,
                TotalAmount = x.TotalAmount,
                CreatedAt = x.CreatedAt,
                CreatedBy = x.CreatedBy
            };

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(EventDetail uiProd)
        {
            NursingHomeContext db = new NursingHomeContext();
            EventDetail dbProd = db.EventDetails.FirstOrDefault(p => p.EventId == uiProd.EventId);
            if (dbProd == null)
                return RedirectToAction("List");
         

            dbProd.EventName = uiProd.EventName;
            //dbProd.FQty = uiProd.FQty;
            //dbProd.FCost = uiProd.FCost;
            //dbProd.FPrice = uiProd.FPrice;

            dbProd.EventName = uiProd.EventName;
            dbProd.Organizer = uiProd.Organizer;
            dbProd.TargetAudience = uiProd.TargetAudience;
            dbProd.CategoryId = uiProd.CategoryId;
            dbProd.Status = uiProd.Status;
            dbProd.ContactPersonId = uiProd.ContactPersonId;
            dbProd.ContactPhone = uiProd.ContactPhone;
            dbProd.EventLocation = uiProd.EventLocation;
            dbProd.Quota = uiProd.Quota;
            dbProd.Description = uiProd.Description;
            dbProd.MedicalAid = uiProd.MedicalAid;
            dbProd.IsPaid = uiProd.IsPaid;
            dbProd.TotalAmount = uiProd.TotalAmount;

            dbProd.LastModifiedAt = DateTime.Now;
            dbProd.LastModifiedBy = 20;
            if (dbProd.TotalAmount == null)
                dbProd.TotalAmount = 0;

            db.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
                return RedirectToAction("List");

            NursingHomeContext db = new NursingHomeContext();
            EventDetail x = db.EventDetails.FirstOrDefault(p => p.EventId == id);
            if (x == null)
                return RedirectToAction("List");

            db.EventDetails.Remove(x);
            db.SaveChanges();
            return RedirectToAction("List");
        }

    }
}
