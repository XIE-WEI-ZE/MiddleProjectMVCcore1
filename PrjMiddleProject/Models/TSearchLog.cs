using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class TSearchLog
{
    public int SearchId { get; set; }

    public int MemberId { get; set; }

    public string? Keyword { get; set; }

    public DateTime? SearchTime { get; set; }

    public string? UserIp { get; set; }

    public virtual Member Member { get; set; } = null!;
}
