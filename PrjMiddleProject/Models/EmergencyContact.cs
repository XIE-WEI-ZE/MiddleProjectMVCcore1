using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class EmergencyContact
{
    public int FamilyId { get; set; }

    public int MemberId { get; set; }

    public string Name { get; set; } = null!;

    public bool Gender { get; set; }

    public string Relationship { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string? ResidentialAddress { get; set; }
}
