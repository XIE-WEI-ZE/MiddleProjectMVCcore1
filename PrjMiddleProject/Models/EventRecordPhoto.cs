using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class EventRecordPhoto
{
    public int PhotoId { get; set; }

    public int EventRecordId { get; set; }

    public byte[] PhotoData { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public string Photopath { get; set; } = null!;

    public virtual EventRecord EventRecord { get; set; } = null!;
}
