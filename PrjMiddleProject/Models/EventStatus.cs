using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class EventStatus
{
    public int StatusId { get; set; }

    public string StatusName { get; set; } = null!;

    public string? StatusCategory { get; set; }

    public virtual ICollection<EventBatch> EventBatches { get; set; } = new List<EventBatch>();

    public virtual ICollection<EventDetail> EventDetails { get; set; } = new List<EventDetail>();

    public virtual ICollection<EventRecord> EventRecords { get; set; } = new List<EventRecord>();

    public virtual ICollection<RegistrationDetail> RegistrationDetailCurrentStatusNavigations { get; set; } = new List<RegistrationDetail>();

    public virtual ICollection<RegistrationDetail> RegistrationDetailPaymentStatusNavigations { get; set; } = new List<RegistrationDetail>();
}
