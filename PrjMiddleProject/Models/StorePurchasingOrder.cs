using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class StorePurchasingOrder
{
    public int StorePurchasingOrderId { get; set; }

    public int SupplierId { get; set; }

    public DateOnly ArrivalDate { get; set; }
}
