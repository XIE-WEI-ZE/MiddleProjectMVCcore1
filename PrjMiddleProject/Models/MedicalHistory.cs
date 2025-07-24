using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class MedicalHistory
{
    public int MedicalRecordId { get; set; }

    public int MemberId { get; set; }

    public string MedicalConditionName { get; set; } = null!;
}
