using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class DailyHealthRecord
{
    public int HealthRecordId { get; set; }

    public int MemberId { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly RecordDate { get; set; }

    public decimal BodyTemperature { get; set; }

    public int BloodPressure { get; set; }

    public int Pulse { get; set; }

    public string? Remark { get; set; }

    public DateTime CreatedDate { get; set; }

    public string? Iorecord { get; set; }

    public string? CheckPeriod { get; set; }
}
