using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class CareAppointment
{
    public int AppointmentId { get; set; }

    public int MemberId { get; set; }

    public string AppointmentService { get; set; } = null!;

    public DateOnly AppointmentDate { get; set; }

    public string AppointmentTimeSlot { get; set; } = null!;

    public DateTime AppointmentDateTime { get; set; }
}
