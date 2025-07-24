using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class EmployeeDailyPunchTime
{
    public int PunchTimeId { get; set; }

    public int EmployeeId { get; set; }

    public DateTime PunchDate { get; set; }

    public DateTime ClockInTime { get; set; }

    public DateTime ClockOutTime { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
