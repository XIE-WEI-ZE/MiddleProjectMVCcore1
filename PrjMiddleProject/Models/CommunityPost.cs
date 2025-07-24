using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class CommunityPost
{
    public int PostId { get; set; }

    public int MemberId { get; set; }

    public string PostTitle { get; set; } = null!;

    public string PostContent { get; set; } = null!;

    public int? QuotedPostId { get; set; }

    public int? RepliedPostId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string PostStatuses { get; set; } = null!;

    public virtual ICollection<CommunityAttachment> CommunityAttachments { get; set; } = new List<CommunityAttachment>();

    public virtual ICollection<CommunityInteraction> CommunityInteractions { get; set; } = new List<CommunityInteraction>();

    public virtual ICollection<CommunityReply> CommunityReplies { get; set; } = new List<CommunityReply>();

    public virtual ICollection<CommunityPost> InverseQuotedPost { get; set; } = new List<CommunityPost>();

    public virtual ICollection<CommunityPost> InverseRepliedPost { get; set; } = new List<CommunityPost>();

    public virtual CommunityPost? QuotedPost { get; set; }

    public virtual CommunityPost? RepliedPost { get; set; }
}
