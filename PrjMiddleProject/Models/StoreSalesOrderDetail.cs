using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class StoreSalesOrderDetail
{
    public int SalesOrderId { get; set; }

    public int StoreProductId { get; set; }

    public decimal QuantityOfSales { get; set; }

    public DateOnly? ExpiryDate { get; set; }

    public virtual StoreSalesOrder SalesOrder { get; set; } = null!;
}
