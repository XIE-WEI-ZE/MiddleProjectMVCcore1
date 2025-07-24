using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class CommunityReportedContent
{
    public int ReportedContentId { get; set; }

    public string Category { get; set; } = null!;

    public int? PostId { get; set; }

    public int? ReplyId { get; set; }

    public int? OtherReferenceId { get; set; }

    public DateTime CreatedAt { get; set; }
}
