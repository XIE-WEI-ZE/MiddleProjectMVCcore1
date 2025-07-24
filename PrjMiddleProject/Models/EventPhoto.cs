using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class EventPhoto
{
    public int PhotoId { get; set; }

    public int EventId { get; set; }

    public byte[] PhotoData { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public string? Photopath { get; set; }

    public virtual Employee CreatedByNavigation { get; set; } = null!;

    public virtual EventDetail Event { get; set; } = null!;
}
