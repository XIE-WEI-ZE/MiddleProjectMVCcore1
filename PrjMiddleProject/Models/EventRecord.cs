using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class EventRecord
{
    public int EventRecordId { get; set; }

    public int BatchId { get; set; }

    public string Content { get; set; } = null!;

    public int Status { get; set; }

    public string? InternalRemarks { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? LastModifiedAt { get; set; }

    public int? LastModifiedBy { get; set; }

    public virtual EventBatch Batch { get; set; } = null!;

    public virtual ICollection<EventRecordPhoto> EventRecordPhotos { get; set; } = new List<EventRecordPhoto>();

    public virtual EventStatus StatusNavigation { get; set; } = null!;
}
