using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class EmployeeWorkTask
{
    public int WorkTaskId { get; set; }

    public int WorkTypeId { get; set; }

    public DateOnly TaskDate { get; set; }

    public string? MemberId { get; set; }

    public string? MemberRoom { get; set; }

    public string? MemberBed { get; set; }

    public virtual ICollection<EmployeeWorkAssignment> EmployeeWorkAssignments { get; set; } = new List<EmployeeWorkAssignment>();

    public virtual EmployeeWorkType WorkType { get; set; } = null!;
}
