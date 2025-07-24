using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class EmployeeDailyStaff
{
    public int DailyStaffId { get; set; }

    public DateTime ScheduleDate { get; set; }

    public string ShiftId { get; set; } = null!;

    public int TotalStaff { get; set; }

    public int ActualAttendance { get; set; }

    public int LeaveCount { get; set; }

    public virtual EmployeeShift Shift { get; set; } = null!;
}
