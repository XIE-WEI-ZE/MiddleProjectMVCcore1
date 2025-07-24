using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class RoomBillingRecordTable
{
    public string BillingId { get; set; } = null!;

    public string BedId { get; set; } = null!;

    public string? DetailId { get; set; }

    public bool BillingStatus { get; set; }

    public virtual RoomBedTable Bed { get; set; } = null!;

    public virtual RoomBillingDetailTable? Detail { get; set; }
}
