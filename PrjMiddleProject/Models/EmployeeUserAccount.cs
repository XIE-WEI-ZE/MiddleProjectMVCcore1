using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class EmployeeUserAccount
{
    public int UserAccountId { get; set; }

    public int EmployeeId { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<EmployeePasswordResetRequest> EmployeePasswordResetRequests { get; set; } = new List<EmployeePasswordResetRequest>();
}
