using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class CommunityReport
{
    public int ReportId { get; set; }

    public int ReportMemberId { get; set; }

    public string TargetType { get; set; } = null!;

    public int? TargetMemberId { get; set; }

    public int ReportedContentId { get; set; }

    public string ReportReasonType { get; set; } = null!;

    public DateTime ReportedAt { get; set; }

    public string ReportStatus { get; set; } = null!;

    public int? AssignedEmployeeId { get; set; }

    public DateTime? ResolvedAt { get; set; }

    public string? Notes { get; set; }
}
