using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class StoreProduct
{
    public int StoreProductId { get; set; }

    public string StoreProductName { get; set; } = null!;

    public string QuantityPerUnit { get; set; } = null!;

    public decimal UnitsInStock { get; set; }

    public int SupplierId { get; set; }

    public virtual StoreSupplier Supplier { get; set; } = null!;
}
