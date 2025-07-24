using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class EmployeeShiftLeave
{
    public int LeaveId { get; set; }

    public int EmployeeId { get; set; }

    public DateTime DateFilled { get; set; }

    public string LeaveType { get; set; } = null!;

    public string LeaveTypeAlias { get; set; } = null!;

    public DateTime StartDateTime { get; set; }

    public DateTime EndDateTime { get; set; }

    public string LeaveDays { get; set; } = null!;

    public string ApplicationReason { get; set; } = null!;

    public string? Attachment { get; set; }

    public string? Agent { get; set; }

    public string ApprovalStatus { get; set; } = null!;
}
