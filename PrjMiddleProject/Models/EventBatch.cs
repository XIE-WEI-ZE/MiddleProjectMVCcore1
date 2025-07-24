using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class EventBatch
{
    public int EventId { get; set; }

    public int BatchId { get; set; }

    public DateTime EventDateTimeStar { get; set; }

    public DateTime EventDateTimeEnd { get; set; }

    public DateTime RegistrationDateStar { get; set; }

    public DateTime RegistrationDateEnd { get; set; }

    public int Status { get; set; }

    public string? Recurrence { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? LastModifiedAt { get; set; }

    public int? LastModifiedBy { get; set; }

    public virtual Employee CreatedByNavigation { get; set; } = null!;

    public virtual EventDetail Event { get; set; } = null!;

    public virtual ICollection<EventRecord> EventRecords { get; set; } = new List<EventRecord>();

    public virtual Employee? LastModifiedByNavigation { get; set; }

    public virtual ICollection<RegistrationDetail> RegistrationDetails { get; set; } = new List<RegistrationDetail>();

    public virtual EventStatus StatusNavigation { get; set; } = null!;
}
