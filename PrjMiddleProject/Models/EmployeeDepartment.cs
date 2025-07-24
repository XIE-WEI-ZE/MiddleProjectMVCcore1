using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class EmployeeDepartment
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public string DepartmentDescription { get; set; } = null!;
}
