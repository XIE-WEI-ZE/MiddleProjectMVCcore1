using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class StorePurchasingOrderDetail
{
    public int StorePurchasingOrderId { get; set; }

    public int StoreProductId { get; set; }

    public decimal QuantityIn { get; set; }

    public DateOnly? ExpiryDate { get; set; }

    public virtual StorePurchasingOrder StorePurchasingOrder { get; set; } = null!;
}
