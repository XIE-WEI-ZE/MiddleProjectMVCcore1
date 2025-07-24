using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class EventDetail
{
    public int EventId { get; set; }

    public string EventName { get; set; } = null!;

    public string Organizer { get; set; } = null!;

    public string TargetAudience { get; set; } = null!;

    public bool RequiresFamilyInsurance { get; set; }

    public int CategoryId { get; set; }

    public int Status { get; set; }

    public int ContactPersonId { get; set; }

    public string ContactPhone { get; set; } = null!;

    public string EventLocation { get; set; } = null!;

    public int? Quota { get; set; }

    public string Description { get; set; } = null!;

    public string? MedicalAid { get; set; }

    public bool IsPaid { get; set; }

    public decimal? TotalAmount { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? LastModifiedAt { get; set; }

    public int? LastModifiedBy { get; set; }

    public virtual EventCategory Category { get; set; } = null!;

    public virtual Employee CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<EventBatch> EventBatches { get; set; } = new List<EventBatch>();

    public virtual ICollection<EventPhoto> EventPhotos { get; set; } = new List<EventPhoto>();

    public virtual Employee? LastModifiedByNavigation { get; set; }

    public virtual EventStatus StatusNavigation { get; set; } = null!;
}
