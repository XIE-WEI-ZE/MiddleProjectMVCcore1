using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class EmployeePasswordResetRequest
{
    public int RequestId { get; set; }

    public int UserAccountId { get; set; }

    public string ResetToken { get; set; } = null!;

    public DateTime RequestDate { get; set; }

    public DateTime ExpiryDate { get; set; }

    public bool IsUsed { get; set; }

    public virtual EmployeeUserAccount UserAccount { get; set; } = null!;
}
