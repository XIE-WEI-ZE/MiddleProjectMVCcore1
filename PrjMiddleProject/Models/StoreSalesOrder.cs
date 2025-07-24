using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class StoreSalesOrder
{
    public int SalesOrderId { get; set; }

    public DateOnly OrderDate { get; set; }

    public string CustomerName { get; set; } = null!;

    public DateOnly? ReceivedDate { get; set; }

    public bool OrderStatus { get; set; }
}
