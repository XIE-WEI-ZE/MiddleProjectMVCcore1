using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class RegistrationParticipant
{
    public int RegistrationId { get; set; }

    public int CompanionId { get; set; }

    public string Name { get; set; } = null!;

    public string NationalId { get; set; } = null!;

    public string? Email { get; set; }

    public string Address { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    public string ContactPhone { get; set; } = null!;

    public string? OtherRemarks { get; set; }

    public string EmergencyContactName { get; set; } = null!;

    public string EmergencyContactPhone { get; set; } = null!;

    public int Status { get; set; }

    public string? InternalRemarks { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? LastModifiedAt { get; set; }

    public int? LastModifiedBy { get; set; }

    public virtual RegistrationDetail Registration { get; set; } = null!;

    public virtual EventStatus StatusNavigation { get; set; } = null!;
}
