using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class CommunityReply
{
    public int ReplyId { get; set; }

    public int MemberId { get; set; }

    public int PostId { get; set; }

    public string ReplyContent { get; set; } = null!;

    public DateTime RepliedAt { get; set; }

    public string ReplyStatuses { get; set; } = null!;

    public virtual CommunityPost Post { get; set; } = null!;
}
