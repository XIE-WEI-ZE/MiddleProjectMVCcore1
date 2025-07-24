using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class EmployeeSalarySummary
{
    public int SalaryId { get; set; }

    public int EmployeeId { get; set; }

    public DateTime SalaryYearMonth { get; set; }

    public int MonthlySalary { get; set; }

    public DateTime SalaryTransferDate { get; set; }
}
