using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class EmployeeShiftSchedule
{
    public int ScheduleId { get; set; }

    public int EmployeeId { get; set; }

    public int? LeaveId { get; set; }

    public DateTime ScheduleDate { get; set; }

    public string ShiftId { get; set; } = null!;

    public string AttendanceStatus { get; set; } = null!;

    public virtual EmployeeShift Shift { get; set; } = null!;
}
