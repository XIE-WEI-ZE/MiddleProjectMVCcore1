using PrjMiddleProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PrjMiddleProject.Models;

public partial class ShopProduct
{
    [DisplayName("序號")]
    public int ProductId { get; set; }
    [Required(ErrorMessage = "產品名稱不能為空白")]
    [DisplayName("產品名稱")]
    public string ProductName { get; set; } = null!;
    [DisplayName("創建時間")]
    public DateTime CreateAt { get; set; }
    [Required(ErrorMessage = "原價必填")]
    [DisplayName("原價")]
    public int OriginalPrice { get; set; }
    [DisplayName("折扣率")]
    public decimal? DiscountRate { get; set; }
    [Required(ErrorMessage = "售價必填")]
    [DisplayName("售價")]
    public int SalePrice { get; set; }
    [DisplayName("供應商序號")]
    public int? SupplierId { get; set; }
    [DisplayName("類別序號")]
    public int? CategoryId { get; set; }
    [Required(ErrorMessage = "數量不能為空")]
    [DisplayName("數量")]
    public short Quantity { get; set; }
    [Required(ErrorMessage = "庫存不能為空")]
    [DisplayName("庫存")]
    public short Stock { get; set; }
    [DisplayName("已停售")]
    public bool Discontinued { get; set; }
    [DisplayName("摘要")]
    public string? Summary { get; set; }
    [DisplayName("內容")]
    public string? Content { get; set; }
    [DisplayName("商品圖片(大圖)")]
    public string? LargePhotoPath { get; set; }
    [DisplayName("商品圖片(小圖)")]
    public string? ThumbnailPhotoPath { get; set; }

    public virtual ShopCategory? Category { get; set; }

    public virtual ICollection<ShopOrderDetail> ShopOrderDetails { get; set; } = new List<ShopOrderDetail>();

    public virtual ICollection<ShopProductPhoto> ShopProductPhotos { get; set; } = new List<ShopProductPhoto>();
}
