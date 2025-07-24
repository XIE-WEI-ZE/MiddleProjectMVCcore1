using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class EmployeeShift
{
    public string ShiftId { get; set; } = null!;

    public string ShiftName { get; set; } = null!;

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public virtual ICollection<EmployeeDailyAttendance> EmployeeDailyAttendances { get; set; } = new List<EmployeeDailyAttendance>();

    public virtual ICollection<EmployeeDailyStaff> EmployeeDailyStaffs { get; set; } = new List<EmployeeDailyStaff>();

    public virtual ICollection<EmployeeShiftSchedule> EmployeeShiftSchedules { get; set; } = new List<EmployeeShiftSchedule>();
}
