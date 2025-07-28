using Microsoft.AspNetCore.Mvc;
using PrjMiddleProject.Models;
using PrjMiddleProject.ViewModels;

namespace PrjMiddleProject.Controllers
{
    public class ShopCategoryController : Controller
    {
        private readonly NursingHomeContext _context;

        public ShopCategoryController(NursingHomeContext context)
        {
            _context = context;
        }
        public IActionResult List(CKeywordViewModel vm, int page = 1, int pageSize = 10)
        {
            //關鍵字搜尋
            string keyword = vm.txtKeyword;
            IEnumerable<ShopCategory> datas = null;
            
            if (string.IsNullOrEmpty(keyword))
            {
                datas = from p in _context.ShopCategories
                        select p;
            }
            else
            {
                datas = _context.ShopCategories.Where(p => p.CategoryName.Contains(keyword));
            }
            // 加入共用分頁邏輯（ViewModels.CPagination）
            int totalPages;
            var pagedData = CPagination.Paginate(datas, page, pageSize, out totalPages);

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.Keyword = vm.txtKeyword;
            ViewBag.PageSize = pageSize;
            ViewBag.CountStart = (page - 1) * pageSize;

            // 傳入 PaginationInfo 供 Razor Partial 使用
            ViewBag.PaginationInfo = new CPaginationInfo
            {
                CurrentPage = page,
                TotalPages = totalPages,
                PageSize = pageSize,
                Keyword = vm.txtKeyword,
                ActionName = "List"
            };
            return View(pagedData);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ShopCategory p)
        {
            
            _context.ShopCategories.Add(p);
            _context.SaveChanges();
            return RedirectToAction("List");
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("List");
            }
            
            ShopCategory x = _context.ShopCategories.FirstOrDefault(p => p.CategoryId == id);
            if (x == null)
            {
                return RedirectToAction("List");
            }
            //檢查此類別是否有商品
            bool hasProducts = _context.ShopProducts.Any(p => p.CategoryId == x.CategoryId);
            if (hasProducts)
            {
                TempData["Msg"] = $"刪除失敗: 類別「{x.CategoryName}」底下有商品，請先移除相關商品。";
                return RedirectToAction("List");
            }
            _context.ShopCategories.Remove(x);
            _context.SaveChanges();
            return RedirectToAction("List");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("List");
            }
            
            ShopCategory x = _context.ShopCategories.FirstOrDefault(p => p.CategoryId == id);
            if (x == null)
            {
                return RedirectToAction("List");
            }
            return View(x);
        }
        [HttpPost]
        public IActionResult Edit(ShopCategory uiCat)
        {
            
            ShopCategory dbCat = _context.ShopCategories.FirstOrDefault(p => p.CategoryId == uiCat.CategoryId);
            if (dbCat == null)
            {
                return RedirectToAction("List");
            }
            dbCat.CategoryName = uiCat.CategoryName;
            dbCat.Description = uiCat.Description;
            //存回資料庫
            _context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
