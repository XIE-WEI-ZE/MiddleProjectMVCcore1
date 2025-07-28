using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrjMiddleProject.Models;
using PrjMiddleProject.ViewModels;
using System;
using System.IO;
using System.Linq;

[RequestSizeLimit(100_000_000)] // 設為 100MB，整個 Controller 都適用
public class ShopProductController : Controller
{
    private readonly NursingHomeContext _context;
    private readonly IWebHostEnvironment _env;

    public ShopProductController(NursingHomeContext context, IWebHostEnvironment env)
    {
        _context = context;
        _env = env;
    }

    public IActionResult List(CKeywordViewModel p, int page = 1, int pageSize = 10)
    {
        
        IEnumerable<ShopProduct> datas = null;
        if (string.IsNullOrEmpty(p.txtKeyword))
        {
            datas = _context.ShopProducts
                    .Include(p => p.Category)
                    .OrderBy(p => p.ProductId)
                    .ToList();
        }
        else
        {
            datas = _context.ShopProducts
                        .Include(p => p.Category)
                        .Where(x => x.ProductName.Contains(p.txtKeyword))
                        .OrderBy(p => p.ProductId)
                        .ToList();
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


    public IActionResult Create()
    {
        var categories = _context.ShopCategories
            .OrderBy(c => c.CategoryName)
            .ToList();

        ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CShopProductWrap vm)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Categories = new SelectList(_context.ShopCategories.ToList(), "CategoryId", "CategoryName");
            return View(vm);
        }

        var product = vm.Product;
        product.CreateAt = DateTime.Now;
        _context.ShopProducts.Add(product);
        await _context.SaveChangesAsync(); // 先存 product 拿到 ProductId

        // 儲存圖片路徑
        if (vm.LargePhotos != null && vm.ThumbnailPhotos != null &&
            vm.LargePhotos.Count == vm.ThumbnailPhotos.Count)
        {
            for (int i = 0; i < vm.LargePhotos.Count; i++)
            {
                var large = vm.LargePhotos[i];
                var thumb = vm.ThumbnailPhotos[i];

                string largeFileName = Guid.NewGuid().ToString() + Path.GetExtension(large.FileName);
                string thumbFileName = Guid.NewGuid().ToString() + Path.GetExtension(thumb.FileName);

                string largePath = Path.Combine(_env.WebRootPath, "images", "ShopProductLarge", largeFileName);
                string thumbPath = Path.Combine(_env.WebRootPath, "images", "ShopProductThumb", thumbFileName);

                using (var fs = new FileStream(largePath, FileMode.Create)) await large.CopyToAsync(fs);
                using (var fs = new FileStream(thumbPath, FileMode.Create)) await thumb.CopyToAsync(fs);

                var photo = new ShopProductPhoto
                {
                    ProductId = product.ProductId,
                    LargePhotoPath = "/images/ShopProductLarge/" + largeFileName,
                    ThumbnailPhotoPath = "/images/ShopProductThumb/" + thumbFileName,
                    ModifiedDate = DateTime.Now
                };
                _context.ShopProductPhotos.Add(photo);

                if (i == 0)
                {
                    product.LargePhotoPath = photo.LargePhotoPath;
                    product.ThumbnailPhotoPath = photo.ThumbnailPhotoPath;
                }
            }

            await _context.SaveChangesAsync();
        }

        return RedirectToAction("List");
    }

    public IActionResult Edit(int id)
    {
        var product = _context.ShopProducts
                        .Include(p => p.Category)
                        .Include(p => p.ShopProductPhotos)
                        .Select(p => new ShopProduct
                        {
                            ProductId = p.ProductId,
                            ProductName = p.ProductName,
                            CategoryId = p.CategoryId,
                            Category = p.Category,
                            OriginalPrice = p.OriginalPrice,
                            SalePrice = p.SalePrice,
                            DiscountRate = p.DiscountRate,
                            Quantity = p.Quantity,
                            Stock = p.Stock,
                            SupplierId = p.SupplierId,
                            Summary = p.Summary,
                            Content = p.Content,
                            Discontinued = p.Discontinued,
                            ShopProductPhotos = p.ShopProductPhotos.Select(photo => new ShopProductPhoto
                            {
                                ProductPhotoId = photo.ProductPhotoId,
                                LargePhotoPath = photo.LargePhotoPath,
                                ThumbnailPhotoPath = photo.ThumbnailPhotoPath
                            }).ToList()
                        })
                        .FirstOrDefault(p => p.ProductId == id);


        if (product == null)
            return NotFound();

        var categories = _context.ShopCategories.ToList();
        ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName", product.CategoryId);

        var vm = new CShopProductWrap { Product = product };
        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, CShopProductWrap vm)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Categories = new SelectList(_context.ShopCategories.ToList(), "CategoryId", "CategoryName", vm.Product.CategoryId);
            return View(vm);
        }

        var product = _context.ShopProducts
                        .Include(p => p.ShopProductPhotos)
                        .FirstOrDefault(p => p.ProductId == id);
        if (product == null)
            return NotFound();

        // 更新基本欄位
        product.ProductName = vm.Product.ProductName;
        product.OriginalPrice = vm.Product.OriginalPrice;
        product.SalePrice = vm.Product.SalePrice;
        product.DiscountRate = vm.Product.DiscountRate;
        product.CategoryId = vm.Product.CategoryId;
        product.SupplierId = vm.Product.SupplierId;
        product.Quantity = vm.Product.Quantity;
        product.Stock = vm.Product.Stock;
        product.Summary = vm.Product.Summary;
        product.Content = vm.Product.Content;
        product.Discontinued = vm.Product.Discontinued;

        // ✅ 若有上傳新圖片，處理圖片更新
        bool hasNewImages = vm.LargePhotos != null && vm.ThumbnailPhotos != null &&
                            vm.LargePhotos.Count == vm.ThumbnailPhotos.Count && vm.LargePhotos.Count > 0;

        if (hasNewImages)
        {
            // 1. 刪除原有圖片檔案和資料庫紀錄
            foreach (var oldPhoto in product.ShopProductPhotos)
            {
                string largePath = Path.Combine(_env.WebRootPath, oldPhoto.LargePhotoPath?.TrimStart('/') ?? "");
                string thumbPath = Path.Combine(_env.WebRootPath, oldPhoto.ThumbnailPhotoPath?.TrimStart('/') ?? "");

                if (System.IO.File.Exists(largePath)) System.IO.File.Delete(largePath);
                if (System.IO.File.Exists(thumbPath)) System.IO.File.Delete(thumbPath);
            }

            _context.ShopProductPhotos.RemoveRange(product.ShopProductPhotos);
            product.LargePhotoPath = null;
            product.ThumbnailPhotoPath = null;
            await _context.SaveChangesAsync(); // ⚠️ 清掉舊圖

            // 2. 儲存新圖片（只存路徑）
            for (int i = 0; i < vm.LargePhotos.Count; i++)
            {
                var large = vm.LargePhotos[i];
                var thumb = vm.ThumbnailPhotos[i];

                string largeFileName = Guid.NewGuid() + Path.GetExtension(large.FileName);
                string thumbFileName = Guid.NewGuid() + Path.GetExtension(thumb.FileName);

                string largePath = Path.Combine(_env.WebRootPath, "images", "ShopProductLarge", largeFileName);
                string thumbPath = Path.Combine(_env.WebRootPath, "images", "ShopProductThumb", thumbFileName);

                using (var fs = new FileStream(largePath, FileMode.Create)) await large.CopyToAsync(fs);
                using (var fs = new FileStream(thumbPath, FileMode.Create)) await thumb.CopyToAsync(fs);

                var newPhoto = new ShopProductPhoto
                {
                    ProductId = product.ProductId,
                    LargePhotoPath = "/images/ShopProductLarge/" + largeFileName,
                    ThumbnailPhotoPath = "/images/ShopProductThumb/" + thumbFileName,
                    ModifiedDate = DateTime.Now
                };

                _context.ShopProductPhotos.Add(newPhoto);

                // 第一張圖設定為主圖
                if (i == 0)
                {
                    product.LargePhotoPath = newPhoto.LargePhotoPath;
                    product.ThumbnailPhotoPath = newPhoto.ThumbnailPhotoPath;
                }
            }
        }

        await _context.SaveChangesAsync();
        return RedirectToAction("List");
    }



    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        // 1. 從資料庫取得完整資料（包含圖片主鍵）
        var product = _context.ShopProducts
                        .Where(p => p.ProductId == id)
                        .Select(p => new ShopProduct
                        {
                            ProductId = p.ProductId,
                            ShopProductPhotos = p.ShopProductPhotos
                                .Select(photo => new ShopProductPhoto
                                {
                                    ProductPhotoId = photo.ProductPhotoId, // 必須有主鍵
                                    LargePhotoPath = photo.LargePhotoPath,
                                    ThumbnailPhotoPath = photo.ThumbnailPhotoPath
                                }).ToList()
                        })
                        .FirstOrDefault();

        if (product == null)
            return NotFound();

        // 2. 刪除圖片實體檔案（磁碟）
        foreach (var photo in product.ShopProductPhotos)
        {
            if (!string.IsNullOrEmpty(photo.LargePhotoPath))
            {
                string largePath = Path.Combine(
                    _env.WebRootPath,
                    photo.LargePhotoPath.TrimStart('/').Replace('/', Path.DirectorySeparatorChar)
                );
                if (System.IO.File.Exists(largePath))
                    System.IO.File.Delete(largePath);
            }

            if (!string.IsNullOrEmpty(photo.ThumbnailPhotoPath))
            {
                string thumbPath = Path.Combine(
                    _env.WebRootPath,
                    photo.ThumbnailPhotoPath.TrimStart('/').Replace('/', Path.DirectorySeparatorChar)
                );
                if (System.IO.File.Exists(thumbPath))
                    System.IO.File.Delete(thumbPath);
            }
        }

        // 3. 刪除資料庫資料
        if (product.ShopProductPhotos.Any())
            _context.ShopProductPhotos.RemoveRange(product.ShopProductPhotos);

        _context.ShopProducts.Remove(product);
        await _context.SaveChangesAsync();

        return RedirectToAction("List");
    }




}
