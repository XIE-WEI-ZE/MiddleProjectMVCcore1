using System;
using System.Collections.Generic;

namespace PrjMiddleProject.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string? EmploymentStatus { get; set; }

    public bool? IsAdmin { get; set; }

    public bool? IsSupervisor { get; set; }

    public string? EmployeeIdnumber { get; set; }

    public int? DepartmentId { get; set; }

    public int? JobTitleId { get; set; }

    public string? Name { get; set; }

    public string? Gender { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string? MobileNumber { get; set; }

    public string? Email { get; set; }

    public DateOnly? DateOfHire { get; set; }

    public string? CurrentAddress { get; set; }

    public string? RegisteredAddress { get; set; }

    public string? EducationLevel { get; set; }

    public string? YearsOfService { get; set; }

    public decimal? Height { get; set; }

    public decimal? Weight { get; set; }

    public bool? PoliceClearanceCertificate { get; set; }

    public string? EmergencyContactPerson { get; set; }

    public string? EmergencyContactRelationship { get; set; }

    public string? EmergencyContactPhone { get; set; }

    public string? PayrollBankAccount { get; set; }

    public string? Photopath { get; set; }

    public virtual ICollection<EmployeeDailyAttendance> EmployeeDailyAttendances { get; set; } = new List<EmployeeDailyAttendance>();

    public virtual ICollection<EmployeeDailyPunchTime> EmployeeDailyPunchTimes { get; set; } = new List<EmployeeDailyPunchTime>();

    public virtual ICollection<EmployeeWorkAssignment> EmployeeWorkAssignments { get; set; } = new List<EmployeeWorkAssignment>();

    public virtual ICollection<EventBatch> EventBatchCreatedByNavigations { get; set; } = new List<EventBatch>();

    public virtual ICollection<EventBatch> EventBatchLastModifiedByNavigations { get; set; } = new List<EventBatch>();

    public virtual ICollection<EventCategory> EventCategoryCreatedByNavigations { get; set; } = new List<EventCategory>();

    public virtual ICollection<EventCategory> EventCategoryLastModifiedByNavigations { get; set; } = new List<EventCategory>();

    public virtual ICollection<EventDetail> EventDetailCreatedByNavigations { get; set; } = new List<EventDetail>();

    public virtual ICollection<EventDetail> EventDetailLastModifiedByNavigations { get; set; } = new List<EventDetail>();

    public virtual ICollection<EventPhoto> EventPhotos { get; set; } = new List<EventPhoto>();

    public virtual ICollection<RegistrationDetail> RegistrationDetails { get; set; } = new List<RegistrationDetail>();
}
