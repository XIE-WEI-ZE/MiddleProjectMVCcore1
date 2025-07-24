using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class EmployeeWorkType
{
    public int WorkTypeId { get; set; }

    public string WorkTypeName { get; set; } = null!;

    public string RequiredTime { get; set; } = null!;

    public bool IsMemberBounded { get; set; }

    public virtual ICollection<EmployeeWorkTask> EmployeeWorkTasks { get; set; } = new List<EmployeeWorkTask>();
}
