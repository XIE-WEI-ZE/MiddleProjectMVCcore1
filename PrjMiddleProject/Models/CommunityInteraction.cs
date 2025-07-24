using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class CommunityInteraction
{
    public int InteractionId { get; set; }

    public int MemberId { get; set; }

    public int PostId { get; set; }

    public string InteractionType { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual CommunityPost Post { get; set; } = null!;
}
