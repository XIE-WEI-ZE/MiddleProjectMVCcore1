using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class RoomBillingDetailTable
{
    public string DetailId { get; set; } = null!;

    public DateOnly? BillingDate { get; set; }

    public string? PaymentMethod { get; set; }

    public string? BillingItem { get; set; }

    public decimal? BillingAmount { get; set; }
}
