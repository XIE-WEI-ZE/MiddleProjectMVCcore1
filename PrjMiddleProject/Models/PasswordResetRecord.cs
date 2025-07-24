using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class PasswordResetRecord
{
    public int ResetId { get; set; }

    public int MemberId { get; set; }

    public string VerificationCode { get; set; } = null!;

    public bool IsUsed { get; set; }

    public DateTime SentDateTime { get; set; }
}
