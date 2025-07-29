using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PrjMiddleProject.Models;
using PrjMiddleProject.ViewModel;

namespace PrjMiddleProject.Controllers
{
    public class EmployeeController : Controller
    {
        NursingHomeContext db = new NursingHomeContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List(CEmployeeKeywordViewModel vm, string statusFilter)
{
    var query = from e in db.Employees
                join d in db.EmployeeDepartments on e.DepartmentId equals d.DepartmentId
                join j in db.EmployeeJobTitles on e.JobTitleId equals j.JobTitleId
                select new CEmployeeListViewModel
                {
                    EmployeeId = e.EmployeeId,
                    Name = e.Name,
                    DepartmentName = d.DepartmentName,
                    JobName = j.JobName,
                    EmploymentStatus = e.EmploymentStatus
                };

    if (!string.IsNullOrEmpty(vm.txtKeyword))
        query = query.Where(e => e.Name.Contains(vm.txtKeyword));

    if (!string.IsNullOrEmpty(statusFilter))
        query = query.Where(e => e.EmploymentStatus == statusFilter);

    if (!string.IsNullOrEmpty(vm.SelectedDepartment))
        query = query.Where(e => e.DepartmentName == vm.SelectedDepartment);

    if (!string.IsNullOrEmpty(vm.SelectedJobTitle))
        query = query.Where(e => e.JobName == vm.SelectedJobTitle);
            

            // 下拉資料來源
            vm.DepartmentList = db.EmployeeDepartments
        .Select(d => new SelectListItem { Value = d.DepartmentName, Text = d.DepartmentName }).ToList();

    vm.JobTitleList = db.EmployeeJobTitles
        .Select(j => new SelectListItem { Value = j.JobName, Text = j.JobName }).ToList();

    vm.Employees = query.ToList();
    return View(vm);
}

        [HttpGet]
        public JsonResult GetJobTitlesByDepartmentName(string departmentName)
        {
            var jobTitles = db.EmployeeDepartments
                .Where(d => d.DepartmentName == departmentName)
                .Join(db.EmployeeJobTitles,
                      d => d.DepartmentId,
                      j => j.DepartmentId,
                      (d, j) => new { j.JobName })
                .ToList();

            return Json(jobTitles);
        }
        private void PopulateYesNoList()
        {
            ViewBag.YesNoList = new List<SelectListItem>
            {
                new SelectListItem { Text = "是", Value = "true" },
                new SelectListItem { Text = "否", Value = "false" }
            };
        }
        private void PopulateDepartmentList()
        {
            ViewBag.Departments = db.EmployeeDepartments
                .Select(d => new SelectListItem
                {
                    Value = d.DepartmentId.ToString(),
                    Text = d.DepartmentName
                }).ToList();
        }

        private void PopulateJobTitleList()
        {
            ViewBag.JobTitles = db.EmployeeJobTitles
                .Select(j => new SelectListItem
                {
                    Value = j.JobTitleId.ToString(),
                    Text = j.JobName
                })
                .ToList();
        }
        private void PopulateEducationList()
        {
            ViewBag.EducationList = new List<SelectListItem>
            {
                new SelectListItem { Text = "小學", Value = "小學" },
                new SelectListItem { Text = "國中", Value = "國中" },
                new SelectListItem { Text = "高中", Value = "高中" },
                new SelectListItem { Text = "五專", Value = "五專" },
                new SelectListItem { Text = "二技", Value = "二技" },
                new SelectListItem { Text = "四技", Value = "四技" },
                new SelectListItem { Text = "專科", Value = "專科" },
                new SelectListItem { Text = "大學", Value = "大學" },
                new SelectListItem { Text = "碩士", Value = "碩士" },
                new SelectListItem { Text = "博士", Value = "博士" }
            };
        }
        private void PopulateHeightList()
        {
            ViewBag.HeightList = Enumerable.Range(100, 151) // 100 ~ 250
                .Select(h => new SelectListItem
                {
                    Value = h.ToString(),
                    Text = h + " 公分"
                }).ToList();
        }

        private void PopulateWeightList()
        {
            ViewBag.WeightList = Enumerable.Range(30, 171) // 30 ~ 200
                .Select(w => new SelectListItem
                {
                    Value = w.ToString(),
                    Text = w + " 公斤"
                }).ToList();
        }
        private void PopulateRelationshipList()
        {
            ViewBag.RelationshipList = new List<SelectListItem>
            {
                new SelectListItem { Text = "配偶", Value = "配偶" },
                new SelectListItem { Text = "父母", Value = "父母" },
                new SelectListItem { Text = "子女", Value = "子女" },
                new SelectListItem { Text = "兄弟", Value = "兄弟" },
                new SelectListItem { Text = "姊妹", Value = "姊妹" },
                new SelectListItem { Text = "祖父母", Value = "祖父母" },
                new SelectListItem { Text = "孫子女", Value = "孫子女" },
                new SelectListItem { Text = "親戚", Value = "親戚" },
                new SelectListItem { Text = "朋友", Value = "朋友" }
            };
        }
        public IActionResult Create()
        {
            PopulateYesNoList();
            PopulateDepartmentList();
            PopulateEducationList();
            PopulateHeightList();
            PopulateWeightList();
            PopulateRelationshipList();

            // 如果還需要 YesNoList 給 radio (保險起見留著)
            ViewBag.YesNoList = new List<SelectListItem>
            {
                new SelectListItem { Text = "是", Value = "true" },
                new SelectListItem { Text = "否", Value = "false" }
            };

            // ✅ 建立預設值物件
            var emp = new Employee
            {
                DateOfHire = DateTime.Today
            };

            return View(emp); // ✅ 傳入 model，有 DateOfHire 預設值
        }
        [HttpPost]
        public IActionResult Create(Employee p)
        {

            if (!ModelState.IsValid)
            {
                // 印出所有錯誤：
                foreach (var key in ModelState.Keys)
                {
                    var errors = ModelState[key].Errors;
                    foreach (var error in errors)
                    {
                        Console.WriteLine($"欄位: {key}, 錯誤: {error.ErrorMessage}");
                    }
                }

                // 重新帶回表單選項
                PopulateYesNoList();
                PopulateDepartmentList();
                PopulateEducationList();
                PopulateHeightList();
                PopulateWeightList();
                PopulateRelationshipList();

                return View(p);
            }

            // ✅ 上傳圖片處理
            if (p.PhotoFile != null && p.PhotoFile.Length > 0)
            {
                string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/EmployeePhoto");
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(p.PhotoFile.FileName);
                string filePath = Path.Combine(uploadPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    p.PhotoFile.CopyTo(stream);
                }

                // ✅ 寫入 Photopath 欄位 → 資料庫存相對路徑即可
                p.Photopath = "/images/EmployeePhoto/" + fileName;
            }
            if (p.DateOfHire.HasValue)
            {
                var today = DateTime.Today;
                var hireDate = p.DateOfHire.Value;  // ✅ 解開 Nullable

                var totalMonths = (today.Year - hireDate.Year) * 12 + today.Month - hireDate.Month;

                if (today.Day < hireDate.Day)      // ✅ 確保用的是 hireDate.Day
                    totalMonths--;

                int years = totalMonths / 12;
                int months = totalMonths % 12;

                p.YearsOfService = $"{years} 年 {months} 月";
            }

            try
            {
                db.Employees.Add(p);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ 發生錯誤：" + ex.Message);
                Console.WriteLine("❌ 錯誤細節：" + ex.InnerException?.Message);
                throw;
            }
            return RedirectToAction("List");
           
        }
        [HttpGet]
        public JsonResult GetJobTitlesByDepartment(int departmentId)
        {
            var jobTitles = db.EmployeeJobTitles
                .Where(j => j.DepartmentId == departmentId)
                .Select(j => new
                {
                    j.JobTitleId,
                    j.JobName
                }).ToList();

            return Json(jobTitles);
        }
        public IActionResult Details(int id)
        {
            var emp = (from e in db.Employees
                       join d in db.EmployeeDepartments on e.DepartmentId equals d.DepartmentId
                       join j in db.EmployeeJobTitles on e.JobTitleId equals j.JobTitleId
                       where e.EmployeeId == id
                       select new CEmployeeDetailsViewModel
                       {
                           EmployeeId = e.EmployeeId,
                           Name = e.Name,
                           Gender = e.Gender,
                           DateOfBirth = e.DateOfBirth,
                           DateOfHire = e.DateOfHire,
                           EmployeeIDNumber = e.EmployeeIdnumber,
                           YearsOfService = e.YearsOfService,
                           EmploymentStatus = e.EmploymentStatus,
                           DepartmentName = d.DepartmentName,
                           JobTitleName = j.JobName,
                           MobileNumber = e.MobileNumber,
                           Email = e.Email,
                           CurrentAddress = e.CurrentAddress,
                           RegisteredAddress = e.RegisteredAddress,
                           EducationLevel = e.EducationLevel,
                           Height = e.Height,
                           Weight = e.Weight,
                           PoliceClearanceCertificate = e.PoliceClearanceCertificate,
                           EmergencyContactPerson = e.EmergencyContactPerson,
                           EmergencyContactRelationship = e.EmergencyContactRelationship,
                           EmergencyContactPhone = e.EmergencyContactPhone,
                           PayrollBankAccount = e.PayrollBankAccount,
                           Photopath = e.Photopath
                       }).FirstOrDefault();

            if (emp == null)
                return NotFound();

            return View(emp);
        }
        public IActionResult Edit(int id)
        {
            var emp = (from e in db.Employees
                       where e.EmployeeId == id
                       select e).FirstOrDefault();

            if (emp == null)
                return NotFound();

            // 選單資料
            PopulateYesNoList();
            PopulateDepartmentList();
            PopulateJobTitleList();
            PopulateEducationList();
            PopulateHeightList();
            PopulateWeightList();
            PopulateRelationshipList();

            return View(emp);
        }
        [HttpPost]
        public IActionResult Edit(Employee p)
        {
            if (!ModelState.IsValid)
            {
                // 重新載入下拉選單
                PopulateYesNoList();
                PopulateDepartmentList();
                PopulateJobTitleList();
                PopulateEducationList();
                PopulateHeightList();
                PopulateWeightList();
                PopulateRelationshipList();

                return View(p);
            }

            var empInDb = db.Employees.FirstOrDefault(e => e.EmployeeId == p.EmployeeId);
            if (empInDb == null)
                return NotFound();

            // ✅ 更新欄位
            empInDb.Name = p.Name;
            empInDb.Gender = p.Gender;
            empInDb.DateOfBirth = p.DateOfBirth;
            empInDb.DateOfHire = p.DateOfHire;
            empInDb.EmployeeIdnumber = p.EmployeeIdnumber;
            empInDb.EmploymentStatus = p.EmploymentStatus;
            empInDb.DepartmentId = p.DepartmentId;
            empInDb.JobTitleId = p.JobTitleId;
            empInDb.MobileNumber = p.MobileNumber;
            empInDb.Email = p.Email;
            empInDb.CurrentAddress = p.CurrentAddress;
            empInDb.RegisteredAddress = p.RegisteredAddress;
            empInDb.EducationLevel = p.EducationLevel;
            empInDb.Height = p.Height;
            empInDb.Weight = p.Weight;
            empInDb.IsAdmin = p.IsAdmin;
            empInDb.IsSupervisor = p.IsSupervisor;
            empInDb.PoliceClearanceCertificate = p.PoliceClearanceCertificate;
            empInDb.EmergencyContactPerson = p.EmergencyContactPerson;
            empInDb.EmergencyContactRelationship = p.EmergencyContactRelationship;
            empInDb.EmergencyContactPhone = p.EmergencyContactPhone;
            empInDb.PayrollBankAccount = p.PayrollBankAccount;

            // ✅ 圖片處理
            if (p.PhotoFile != null && p.PhotoFile.Length > 0)
            {
                string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/EmployeePhoto");
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(p.PhotoFile.FileName);
                string filePath = Path.Combine(uploadPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    p.PhotoFile.CopyTo(stream);
                }

                empInDb.Photopath = "/images/EmployeePhoto/" + fileName;
            }

            // ✅ 年資計算
            if (empInDb.DateOfHire.HasValue)
            {
                var today = DateTime.Today;
                var hireDate = empInDb.DateOfHire.Value;

                var totalMonths = (today.Year - hireDate.Year) * 12 + today.Month - hireDate.Month;
                if (today.Day < hireDate.Day)
                    totalMonths--;

                int years = totalMonths / 12;
                int months = totalMonths % 12;
                empInDb.YearsOfService = $"{years} 年 {months} 月";
            }

            db.SaveChanges();

            return RedirectToAction("List");
        }


    }
}
