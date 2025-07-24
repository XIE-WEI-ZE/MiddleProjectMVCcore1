using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class MedicationRecord
{
    public int MedicationId { get; set; }

    public int MemberId { get; set; }

    public string MedicationName { get; set; } = null!;

    public string Dosage { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string? Remark { get; set; }

    public DateTime CreatedDate { get; set; }
}
