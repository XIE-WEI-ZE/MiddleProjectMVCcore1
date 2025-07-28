using Microsoft.AspNetCore.Http;
using PrjMiddleProject.Models;
using System.Collections.Generic;

namespace PrjMiddleProject.ViewModels
{
    public class CShopProductWrap
    {
        public ShopProduct Product { get; set; } = new ShopProduct();

        public List<IFormFile>? LargePhotos { get; set; }
        public List<IFormFile>? ThumbnailPhotos { get; set; }
    }
}
