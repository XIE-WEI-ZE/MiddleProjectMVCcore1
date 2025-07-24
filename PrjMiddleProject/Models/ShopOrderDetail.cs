using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class ShopOrderDetail
{
    public long DetailId { get; set; }

    public long OrderId { get; set; }

    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public short Quantity { get; set; }

    public short? Discount { get; set; }

    public int UnitPrice { get; set; }

    public int Subtotal { get; set; }

    public virtual ShopOrder Order { get; set; } = null!;

    public virtual ShopProduct Product { get; set; } = null!;
}
