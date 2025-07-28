using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PrjMiddleProject.Models;

public partial class ShopCategory
{
    [DisplayName("序號")]
    public int CategoryId { get; set; }
    [Required(ErrorMessage = "請輸入分類名稱")]
    [StringLength(15)]
    [DisplayName("類別名稱")]
    public string CategoryName { get; set; } = null!;
    [DisplayName("類別說明")]
    public string? Description { get; set; }

    public byte[]? Picture { get; set; }

    public virtual ICollection<ShopProduct> ShopProducts { get; set; } = new List<ShopProduct>();
}
