using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class RegistrationDetail
{
    public int RegistrationId { get; set; }

    public int EventBatchId { get; set; }

    public int MemberId { get; set; }

    public int NumberOfPeople { get; set; }

    public int PaymentStatus { get; set; }

    public decimal? AmountDue { get; set; }

    public DateTime RegistrationDateTime { get; set; }

    public int CurrentStatus { get; set; }

    public string? InternalRemarks { get; set; }

    public DateTime? LastModifiedAt { get; set; }

    public int? LastModifiedBy { get; set; }

    public virtual EventStatus CurrentStatusNavigation { get; set; } = null!;

    public virtual EventBatch EventBatch { get; set; } = null!;

    public virtual Employee? LastModifiedByNavigation { get; set; }

    public virtual EventStatus PaymentStatusNavigation { get; set; } = null!;
}
