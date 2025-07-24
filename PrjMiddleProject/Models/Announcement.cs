using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class Announcement
{
    public int AnnouncementId { get; set; }

    public string Title { get; set; } = null!;

    public string AnnouncementContent { get; set; } = null!;

    public string? Attachment { get; set; }

    public string Category { get; set; } = null!;

    public string AnnouncementStatus { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
