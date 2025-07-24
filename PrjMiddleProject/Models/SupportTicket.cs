using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class SupportTicket
{
    public int TicketId { get; set; }

    public int MemberId { get; set; }

    public string? Title { get; set; }

    public string Category { get; set; } = null!;

    public string PriorityLevel { get; set; } = null!;

    public string TicketStatus { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? ResolvedAt { get; set; }

    public DateTime? ClosedAt { get; set; }

    public int? AssignedEmployeeId { get; set; }

    public virtual ICollection<SupportMessage> SupportMessages { get; set; } = new List<SupportMessage>();
}
