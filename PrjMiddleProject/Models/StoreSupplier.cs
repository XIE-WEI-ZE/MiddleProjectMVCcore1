using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class StoreSupplier
{
    public int SupplierId { get; set; }

    public string SupplierName { get; set; } = null!;

    public string SupplierGui { get; set; } = null!;

    public string Contact { get; set; } = null!;

    public string ContactNumber { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual ICollection<StoreProduct> StoreProducts { get; set; } = new List<StoreProduct>();
}
