using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class RoomItemRequestTable
{
    public int StoreProductId { get; set; }

    public int? Quantity { get; set; }

    public decimal? TotalPrice { get; set; }

    public string? Remarks { get; set; }

    public int MemberId { get; set; }

    public int? ProductId { get; set; }

    public virtual Member Member { get; set; } = null!;

    public virtual StoreProduct StoreProduct { get; set; } = null!;
}
