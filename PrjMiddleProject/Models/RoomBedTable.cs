using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class RoomBedTable
{
    public string BedId { get; set; } = null!;

    public string RoomNumber { get; set; } = null!;

    public string? CareType { get; set; }

    public bool BedStatus { get; set; }

    public DateOnly? CheckInDate { get; set; }

    public DateOnly? ExpectedLeaveDate { get; set; }

    public DateOnly? ActualLeaveDate { get; set; }

    public string? LeaveReason { get; set; }

    public string? Remarks { get; set; }

    public virtual RoomTable RoomNumberNavigation { get; set; } = null!;
}
