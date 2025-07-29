using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class RoomTable
{
    public int? MemberId { get; set; }

    public string RoomNumber { get; set; } = null!;

    public string? RoomName { get; set; }

    public bool? RoomType { get; set; }

    public int? BedCount { get; set; }

    public string? ImagePath { get; set; }

    public decimal? RoomPrice { get; set; }

    public virtual Member? Member { get; set; }

    public virtual ICollection<RoomBedTable> RoomBedTables { get; set; } = new List<RoomBedTable>();
}