using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class CommunityAttachment
{
    public int AttachmentId { get; set; }

    public int? PostId { get; set; }

    public int? ReplyId { get; set; }

    public string? IsImage { get; set; }

    public virtual CommunityPost? Post { get; set; }
}
