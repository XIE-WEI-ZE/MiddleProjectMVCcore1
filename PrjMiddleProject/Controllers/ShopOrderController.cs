using Microsoft.AspNetCore.Mvc;
using PrjMiddleProject.Models;
using PrjMiddleProject.ViewModels;

namespace PrjMiddleProject.Controllers
{
    public class ShopOrderController : Controller
    {
        private readonly NursingHomeContext _context;

        public ShopOrderController(NursingHomeContext context)
        {
            _context = context;
        }

        public IActionResult List(CKeywordViewModel p, int page = 1, int pageSize = 10)
        {
            
            IEnumerable<ShopOrder> datas = null;
            if (string.IsNullOrEmpty(p.txtKeyword))
            {
                datas = from d in _context.ShopOrders
                        select d;
            }
            else
            {
                datas = _context.ShopOrders.Where(d => d.CustomerId.Contains(p.txtKeyword));
            }
            // 加入共用分頁邏輯（ViewModels.CPagination）
            int totalPages;
            var pagedData = CPagination.Paginate(datas, page, pageSize, out totalPages);

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.Keyword = p.txtKeyword;
            ViewBag.PageSize = pageSize;
            ViewBag.CountStart = (page - 1) * pageSize;

            // 傳入 PaginationInfo 供 Razor Partial 使用
            ViewBag.PaginationInfo = new CPaginationInfo
            {
                CurrentPage = page,
                TotalPages = totalPages,
                PageSize = pageSize,
                Keyword = p.txtKeyword,
                ActionName = "List"
            };
            return View(pagedData);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("List");
            }
            
            //查詢主檔
            var order = _context.ShopOrders.FirstOrDefault(p => p.OrderId == id);
            if (order == null)
            {
                return RedirectToAction("List");
            }
            //查詢明細(Detail表)
            //加.ToList() 才能符合 List<T> 的屬性型別
            var details = _context.ShopOrderDetails.Where(d => d.OrderId == id).ToList();
            // 動態計算總金額
            int total = 0;
            foreach (var d in details)
            {
                double discount = (d.Discount.HasValue ? (100 - d.Discount.Value) : 100) / 100.0;
                total += (int)(d.UnitPrice * d.Quantity * discount);
            }

            // 同步更新主檔的 TotalAmount
            order.TotalAmount = total;
            _context.SaveChanges();
            //建立ViewModel
            OrderDetailsViewModel vm = new OrderDetailsViewModel
            {
                Order = order,
                Details = details,
                //日後會加上會員與員工資訊(這裡先暫時不查)
                MemberName = "", //日後再查 _context.Members.FirstOrDefault(m => m.MemberId == order.MemberId)
                EmployeeName = ""
            };
            return View(vm);
        }
    }
}
