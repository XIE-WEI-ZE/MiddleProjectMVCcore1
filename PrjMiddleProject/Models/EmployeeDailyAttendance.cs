using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class EmployeeDailyAttendance
{
    public int DailyAttendanceId { get; set; }

    public int EmployeeId { get; set; }

    public DateTime AttendanceDate { get; set; }

    public string ShiftId { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string? LateMinutes { get; set; }

    public string? OvertimeMinutes { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual EmployeeShift Shift { get; set; } = null!;
}
