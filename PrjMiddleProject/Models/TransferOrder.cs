using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class TransferOrder
{
    public int TransferOrderId { get; set; }

    public DateOnly OrderDate { get; set; }

    public DateOnly? TransferDate { get; set; }

    public bool OrderStatus { get; set; }
}
