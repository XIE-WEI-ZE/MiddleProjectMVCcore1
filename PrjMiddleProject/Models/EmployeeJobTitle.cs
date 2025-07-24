using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class EmployeeJobTitle
{
    public int JobTitleId { get; set; }

    public int DepartmentId { get; set; }

    public string JobName { get; set; } = null!;

    public int? JobLevel { get; set; }
}
