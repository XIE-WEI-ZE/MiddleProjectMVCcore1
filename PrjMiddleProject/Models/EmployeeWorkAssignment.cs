using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class EmployeeWorkAssignment
{
    public int AssignmentId { get; set; }

    public int WorkTaskId { get; set; }

    public int EmployeeId { get; set; }

    public DateTime AssignmentDate { get; set; }

    public bool IsPrimary { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual EmployeeWorkTask WorkTask { get; set; } = null!;
}
