using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class SupportMessage
{
    public int MessageId { get; set; }

    public int TicketId { get; set; }

    public string? SenderType { get; set; }

    public string MessageContent { get; set; } = null!;

    public DateTime SentAt { get; set; }

    public virtual SupportTicket Ticket { get; set; } = null!;
}
