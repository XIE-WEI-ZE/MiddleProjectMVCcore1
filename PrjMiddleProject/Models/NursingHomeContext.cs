using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PrjMiddleProject.Models;

public partial class NursingHomeContext : DbContext
{
    public NursingHomeContext()
    {
    }

    public NursingHomeContext(DbContextOptions<NursingHomeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Announcement> Announcements { get; set; }

    public virtual DbSet<CareAppointment> CareAppointments { get; set; }

    public virtual DbSet<CommunityAttachment> CommunityAttachments { get; set; }

    public virtual DbSet<CommunityInteraction> CommunityInteractions { get; set; }

    public virtual DbSet<CommunityPost> CommunityPosts { get; set; }

    public virtual DbSet<CommunityReply> CommunityReplys { get; set; }

    public virtual DbSet<CommunityReport> CommunityReports { get; set; }

    public virtual DbSet<CommunityReportedContent> CommunityReportedContents { get; set; }

    public virtual DbSet<DailyHealthRecord> DailyHealthRecords { get; set; }

    public virtual DbSet<EmergencyContact> EmergencyContacts { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeDailyAttendance> EmployeeDailyAttendances { get; set; }

    public virtual DbSet<EmployeeDailyPunchTime> EmployeeDailyPunchTimes { get; set; }

    public virtual DbSet<EmployeeDailyStaff> EmployeeDailyStaffs { get; set; }

    public virtual DbSet<EmployeeDepartment> EmployeeDepartments { get; set; }

    public virtual DbSet<EmployeeJobTitle> EmployeeJobTitles { get; set; }

    public virtual DbSet<EmployeePasswordResetRequest> EmployeePasswordResetRequests { get; set; }

    public virtual DbSet<EmployeeSalarySummary> EmployeeSalarySummaries { get; set; }

    public virtual DbSet<EmployeeShift> EmployeeShifts { get; set; }

    public virtual DbSet<EmployeeShiftLeave> EmployeeShiftLeaves { get; set; }

    public virtual DbSet<EmployeeShiftSchedule> EmployeeShiftSchedules { get; set; }

    public virtual DbSet<EmployeeUserAccount> EmployeeUserAccounts { get; set; }

    public virtual DbSet<EmployeeWorkAssignment> EmployeeWorkAssignments { get; set; }

    public virtual DbSet<EmployeeWorkTask> EmployeeWorkTasks { get; set; }

    public virtual DbSet<EmployeeWorkType> EmployeeWorkTypes { get; set; }

    public virtual DbSet<EventBatch> EventBatches { get; set; }

    public virtual DbSet<EventCategory> EventCategories { get; set; }

    public virtual DbSet<EventDetail> EventDetails { get; set; }

    public virtual DbSet<EventPhoto> EventPhotos { get; set; }

    public virtual DbSet<EventRecord> EventRecords { get; set; }

    public virtual DbSet<EventRecordPhoto> EventRecordPhotos { get; set; }

    public virtual DbSet<EventStatus> EventStatuses { get; set; }

    public virtual DbSet<MedicalHistory> MedicalHistories { get; set; }

    public virtual DbSet<MedicationRecord> MedicationRecords { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<PasswordResetRecord> PasswordResetRecords { get; set; }

    public virtual DbSet<RegistrationDetail> RegistrationDetails { get; set; }

    public virtual DbSet<RegistrationParticipant> RegistrationParticipants { get; set; }

    public virtual DbSet<RoomBedTable> RoomBedTables { get; set; }

    public virtual DbSet<RoomBillingDetailTable> RoomBillingDetailTables { get; set; }

    public virtual DbSet<RoomBillingRecordTable> RoomBillingRecordTables { get; set; }

    public virtual DbSet<RoomItemRequestTable> RoomItemRequestTables { get; set; }

    public virtual DbSet<RoomTable> RoomTables { get; set; }

    public virtual DbSet<ShopCategory> ShopCategories { get; set; }

    public virtual DbSet<ShopOrder> ShopOrders { get; set; }

    public virtual DbSet<ShopOrderDetail> ShopOrderDetails { get; set; }

    public virtual DbSet<ShopProduct> ShopProducts { get; set; }

    public virtual DbSet<ShopProductPhoto> ShopProductPhotos { get; set; }

    public virtual DbSet<StoreProduct> StoreProducts { get; set; }

    public virtual DbSet<StoreProductsDate> StoreProductsDates { get; set; }

    public virtual DbSet<StorePurchasingOrder> StorePurchasingOrders { get; set; }

    public virtual DbSet<StorePurchasingOrderDetail> StorePurchasingOrderDetails { get; set; }

    public virtual DbSet<StoreSalesOrder> StoreSalesOrders { get; set; }

    public virtual DbSet<StoreSalesOrderDetail> StoreSalesOrderDetails { get; set; }

    public virtual DbSet<StoreSupplier> StoreSuppliers { get; set; }

    public virtual DbSet<SupportMessage> SupportMessages { get; set; }

    public virtual DbSet<SupportTicket> SupportTickets { get; set; }

    public virtual DbSet<TSearchLog> TSearchLogs { get; set; }

    public virtual DbSet<TransferOrder> TransferOrders { get; set; }

    public virtual DbSet<TransferOrderDetail> TransferOrderDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=NursingHome;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Announcement>(entity =>
        {
            entity.HasKey(e => e.AnnouncementId).HasName("PK__Announce__9DE44574733F374F");

            entity.Property(e => e.AnnouncementContent).IsUnicode(false);
            entity.Property(e => e.AnnouncementStatus).HasMaxLength(50);
            entity.Property(e => e.Attachment).HasMaxLength(50);
            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<CareAppointment>(entity =>
        {
            entity.HasKey(e => e.AppointmentId).HasName("PK__CareAppo__8ECDFCA2BB88EC66");

            entity.ToTable("CareAppointment");

            entity.Property(e => e.AppointmentId).HasColumnName("AppointmentID");
            entity.Property(e => e.AppointmentDateTime).HasColumnType("datetime");
            entity.Property(e => e.AppointmentService).HasMaxLength(50);
            entity.Property(e => e.AppointmentTimeSlot).HasMaxLength(50);
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
        });

        modelBuilder.Entity<CommunityAttachment>(entity =>
        {
            entity.HasKey(e => e.AttachmentId).HasName("PK__Communit__442C64BE9C9AD32C");

            entity.Property(e => e.AttachmentId).HasColumnName("AttachmentID");
            entity.Property(e => e.IsImage).HasMaxLength(50);
            entity.Property(e => e.PostId).HasColumnName("PostID");
            entity.Property(e => e.ReplyId).HasColumnName("ReplyID");

            entity.HasOne(d => d.Post).WithMany(p => p.CommunityAttachments)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("FK_CommunityAttachments_CommunityPosts");
        });

        modelBuilder.Entity<CommunityInteraction>(entity =>
        {
            entity.HasKey(e => e.InteractionId).HasName("PK__Communit__922C0496AB88F4B5");

            entity.Property(e => e.InteractionId).HasColumnName("InteractionID");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.InteractionType).HasMaxLength(20);
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.PostId).HasColumnName("PostID");

            entity.HasOne(d => d.Post).WithMany(p => p.CommunityInteractions)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CommunityInteractions_CommunityPosts");
        });

        modelBuilder.Entity<CommunityPost>(entity =>
        {
            entity.HasKey(e => e.PostId).HasName("PK__Communit__AA12601851F485DF");

            entity.Property(e => e.PostId).HasColumnName("PostID");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.PostStatuses).HasMaxLength(20);
            entity.Property(e => e.PostTitle).HasMaxLength(50);
            entity.Property(e => e.QuotedPostId).HasColumnName("QuotedPostID");
            entity.Property(e => e.RepliedPostId).HasColumnName("RepliedPostID");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.QuotedPost).WithMany(p => p.InverseQuotedPost)
                .HasForeignKey(d => d.QuotedPostId)
                .HasConstraintName("FK_CommunityPosts_CommunityPosts");

            entity.HasOne(d => d.RepliedPost).WithMany(p => p.InverseRepliedPost)
                .HasForeignKey(d => d.RepliedPostId)
                .HasConstraintName("FK_CommunityPosts_CommunityPosts1");
        });

        modelBuilder.Entity<CommunityReply>(entity =>
        {
            entity.HasKey(e => e.ReplyId).HasName("PK__Communit__C25E46099E5D68F7");

            entity.Property(e => e.ReplyId).HasColumnName("ReplyID");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.PostId).HasColumnName("PostID");
            entity.Property(e => e.RepliedAt).HasColumnType("datetime");
            entity.Property(e => e.ReplyStatuses).HasMaxLength(10);

            entity.HasOne(d => d.Post).WithMany(p => p.CommunityReplies)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CommunityReplys_CommunityPosts");
        });

        modelBuilder.Entity<CommunityReport>(entity =>
        {
            entity.HasKey(e => e.ReportId).HasName("PK__Communit__D5BD4805C1311311");

            entity.Property(e => e.ReportId).HasColumnName("ReportID");
            entity.Property(e => e.AssignedEmployeeId).HasColumnName("AssignedEmployeeID");
            entity.Property(e => e.Notes).HasMaxLength(255);
            entity.Property(e => e.ReportMemberId).HasColumnName("ReportMemberID");
            entity.Property(e => e.ReportReasonType).HasMaxLength(50);
            entity.Property(e => e.ReportStatus).HasMaxLength(10);
            entity.Property(e => e.ReportedAt).HasColumnType("datetime");
            entity.Property(e => e.ReportedContentId).HasColumnName("ReportedContentID");
            entity.Property(e => e.ResolvedAt).HasColumnType("datetime");
            entity.Property(e => e.TargetMemberId).HasColumnName("TargetMemberID");
            entity.Property(e => e.TargetType).HasMaxLength(20);
        });

        modelBuilder.Entity<CommunityReportedContent>(entity =>
        {
            entity.HasKey(e => e.ReportedContentId).HasName("PK__Communit__1DDC4E3BE27D95F1");

            entity.ToTable("CommunityReportedContent");

            entity.Property(e => e.Category).HasMaxLength(10);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.PostId).HasColumnName("PostID");
            entity.Property(e => e.ReplyId).HasColumnName("ReplyID");
        });

        modelBuilder.Entity<DailyHealthRecord>(entity =>
        {
            entity.HasKey(e => e.HealthRecordId).HasName("PK__DailyHea__3BE0B89D82B53E64");

            entity.ToTable("DailyHealthRecord");

            entity.Property(e => e.HealthRecordId).HasColumnName("HealthRecordID");
            entity.Property(e => e.BodyTemperature).HasColumnType("decimal(4, 1)");
            entity.Property(e => e.CheckPeriod).HasMaxLength(10);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Iorecord)
                .HasMaxLength(10)
                .HasColumnName("IORecord");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<EmergencyContact>(entity =>
        {
            entity.HasKey(e => e.FamilyId).HasName("PK__Emergenc__41D82F4B4D810084");

            entity.ToTable("EmergencyContact");

            entity.Property(e => e.FamilyId).HasColumnName("FamilyID");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(10);
            entity.Property(e => e.Relationship).HasMaxLength(10);
            entity.Property(e => e.ResidentialAddress).HasMaxLength(50);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04FF160AA3784");

            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.CurrentAddress).HasMaxLength(100);
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.EducationLevel).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.EmergencyContactPerson).HasMaxLength(100);
            entity.Property(e => e.EmergencyContactPhone).HasMaxLength(100);
            entity.Property(e => e.EmergencyContactRelationship).HasMaxLength(100);
            entity.Property(e => e.EmployeeIdnumber)
                .HasMaxLength(10)
                .HasColumnName("EmployeeIDNumber");
            entity.Property(e => e.EmploymentStatus).HasMaxLength(100);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.Height).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.JobTitleId).HasColumnName("JobTitleID");
            entity.Property(e => e.MobileNumber).HasMaxLength(20);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.PayrollBankAccount).HasMaxLength(100);
            entity.Property(e => e.Photopath)
                .HasMaxLength(50)
                .HasColumnName("photopath");
            entity.Property(e => e.RegisteredAddress).HasMaxLength(100);
            entity.Property(e => e.Weight).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.YearsOfService).HasMaxLength(100);
        });

        modelBuilder.Entity<EmployeeDailyAttendance>(entity =>
        {
            entity.HasKey(e => e.DailyAttendanceId).HasName("PK__Attendan__BB21816201D1E2AE");

            entity.ToTable("EmployeeDailyAttendance");

            entity.Property(e => e.DailyAttendanceId).HasColumnName("DailyAttendanceID");
            entity.Property(e => e.AttendanceDate).HasColumnType("datetime");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.LateMinutes).HasMaxLength(50);
            entity.Property(e => e.OvertimeMinutes).HasMaxLength(50);
            entity.Property(e => e.ShiftId)
                .HasMaxLength(50)
                .HasColumnName("ShiftID");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeDailyAttendances)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Attendanc__Emplo__681373AD");

            entity.HasOne(d => d.Shift).WithMany(p => p.EmployeeDailyAttendances)
                .HasForeignKey(d => d.ShiftId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Attendanc__Shift__690797E6");
        });

        modelBuilder.Entity<EmployeeDailyPunchTime>(entity =>
        {
            entity.HasKey(e => e.PunchTimeId).HasName("PK__PunchRec__BA7F809371DB2CBE");

            entity.ToTable("EmployeeDailyPunchTime");

            entity.Property(e => e.PunchTimeId).HasColumnName("PunchTimeID");
            entity.Property(e => e.ClockInTime).HasColumnType("datetime");
            entity.Property(e => e.ClockOutTime).HasColumnType("datetime");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.PunchDate).HasColumnType("datetime");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeDailyPunchTimes)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PunchReco__Emplo__65370702");
        });

        modelBuilder.Entity<EmployeeDailyStaff>(entity =>
        {
            entity.HasKey(e => e.DailyStaffId).HasName("PK__DailySta__F50E3AC6FA734C11");

            entity.ToTable("EmployeeDailyStaff");

            entity.Property(e => e.DailyStaffId).HasColumnName("DailyStaffID");
            entity.Property(e => e.ScheduleDate).HasColumnType("datetime");
            entity.Property(e => e.ShiftId)
                .HasMaxLength(50)
                .HasColumnName("ShiftID");

            entity.HasOne(d => d.Shift).WithMany(p => p.EmployeeDailyStaffs)
                .HasForeignKey(d => d.ShiftId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DailyStaf__Shift__625A9A57");
        });

        modelBuilder.Entity<EmployeeDepartment>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BCD47DCAD82");

            entity.ToTable("EmployeeDepartment");

            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.DepartmentDescription).HasMaxLength(50);
            entity.Property(e => e.DepartmentName).HasMaxLength(50);
        });

        modelBuilder.Entity<EmployeeJobTitle>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("EmployeeJobTitle");

            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.JobName).HasMaxLength(50);
            entity.Property(e => e.JobTitleId)
                .ValueGeneratedOnAdd()
                .HasColumnName("JobTitleID");
        });

        modelBuilder.Entity<EmployeePasswordResetRequest>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PK__Password__33A8519A63466E37");

            entity.Property(e => e.RequestId).HasColumnName("RequestID");
            entity.Property(e => e.ExpiryDate).HasColumnType("datetime");
            entity.Property(e => e.RequestDate).HasColumnType("datetime");
            entity.Property(e => e.ResetToken).HasMaxLength(100);
            entity.Property(e => e.UserAccountId).HasColumnName("UserAccountID");

            entity.HasOne(d => d.UserAccount).WithMany(p => p.EmployeePasswordResetRequests)
                .HasForeignKey(d => d.UserAccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PasswordR__UserA__7720AD13");
        });

        modelBuilder.Entity<EmployeeSalarySummary>(entity =>
        {
            entity.HasKey(e => e.SalaryId).HasName("PK__SalarySu__4BE204B7D42507A4");

            entity.ToTable("EmployeeSalarySummary");

            entity.Property(e => e.SalaryId).HasColumnName("SalaryID");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.SalaryTransferDate).HasColumnType("datetime");
            entity.Property(e => e.SalaryYearMonth).HasColumnType("datetime");
        });

        modelBuilder.Entity<EmployeeShift>(entity =>
        {
            entity.HasKey(e => e.ShiftId).HasName("PK__Shift__C0A838E10C06D077");

            entity.ToTable("EmployeeShift");

            entity.Property(e => e.ShiftId)
                .HasMaxLength(50)
                .HasColumnName("ShiftID");
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.ShiftName).HasMaxLength(50);
            entity.Property(e => e.StartTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<EmployeeShiftLeave>(entity =>
        {
            entity.HasKey(e => e.LeaveId).HasName("PK__Leave__796DB979053C59A1");

            entity.ToTable("EmployeeShiftLeave");

            entity.Property(e => e.LeaveId).HasColumnName("LeaveID");
            entity.Property(e => e.Agent).HasMaxLength(50);
            entity.Property(e => e.ApplicationReason).HasMaxLength(50);
            entity.Property(e => e.ApprovalStatus).HasMaxLength(50);
            entity.Property(e => e.Attachment).HasMaxLength(50);
            entity.Property(e => e.DateFilled).HasColumnType("datetime");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.EndDateTime).HasColumnType("datetime");
            entity.Property(e => e.LeaveDays).HasMaxLength(50);
            entity.Property(e => e.LeaveType).HasMaxLength(50);
            entity.Property(e => e.LeaveTypeAlias).HasMaxLength(50);
            entity.Property(e => e.StartDateTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<EmployeeShiftSchedule>(entity =>
        {
            entity.HasKey(e => e.ScheduleId).HasName("PK__Schedule__9C8A5B69EA7D0896");

            entity.ToTable("EmployeeShiftSchedule");

            entity.Property(e => e.ScheduleId).HasColumnName("ScheduleID");
            entity.Property(e => e.AttendanceStatus).HasMaxLength(50);
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.LeaveId).HasColumnName("LeaveID");
            entity.Property(e => e.ScheduleDate).HasColumnType("datetime");
            entity.Property(e => e.ShiftId)
                .HasMaxLength(50)
                .HasColumnName("ShiftID");

            entity.HasOne(d => d.Shift).WithMany(p => p.EmployeeShiftSchedules)
                .HasForeignKey(d => d.ShiftId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Schedule__ShiftI__5CA1C101");
        });

        modelBuilder.Entity<EmployeeUserAccount>(entity =>
        {
            entity.HasKey(e => e.UserAccountId).HasName("PK__Employee__DA6C70BA343D1298");

            entity.ToTable("EmployeeUserAccount");

            entity.Property(e => e.UserAccountId).HasColumnName("UserAccountID");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.PasswordHash).HasMaxLength(100);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<EmployeeWorkAssignment>(entity =>
        {
            entity.HasKey(e => e.AssignmentId).HasName("PK__WorkAssi__32499E57EC507A14");

            entity.ToTable("EmployeeWorkAssignment");

            entity.Property(e => e.AssignmentId).HasColumnName("AssignmentID");
            entity.Property(e => e.AssignmentDate).HasColumnType("datetime");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.WorkTaskId).HasColumnName("WorkTaskID");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeWorkAssignments)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WorkAssig__Emplo__719CDDE7");

            entity.HasOne(d => d.WorkTask).WithMany(p => p.EmployeeWorkAssignments)
                .HasForeignKey(d => d.WorkTaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WorkAssig__WorkT__70A8B9AE");
        });

        modelBuilder.Entity<EmployeeWorkTask>(entity =>
        {
            entity.HasKey(e => e.WorkTaskId).HasName("PK__WorkTask__9A995290C9C0CA5C");

            entity.ToTable("EmployeeWorkTask");

            entity.Property(e => e.WorkTaskId).HasColumnName("WorkTaskID");
            entity.Property(e => e.MemberBed).HasMaxLength(50);
            entity.Property(e => e.MemberId)
                .HasMaxLength(50)
                .HasColumnName("MemberID");
            entity.Property(e => e.MemberRoom).HasMaxLength(50);
            entity.Property(e => e.WorkTypeId).HasColumnName("WorkTypeID");

            entity.HasOne(d => d.WorkType).WithMany(p => p.EmployeeWorkTasks)
                .HasForeignKey(d => d.WorkTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WorkTask__WorkTy__6DCC4D03");
        });

        modelBuilder.Entity<EmployeeWorkType>(entity =>
        {
            entity.HasKey(e => e.WorkTypeId).HasName("PK__WorkType__CCC06CC06F1A88FD");

            entity.ToTable("EmployeeWorkType");

            entity.Property(e => e.WorkTypeId).HasColumnName("WorkTypeID");
            entity.Property(e => e.RequiredTime).HasMaxLength(50);
            entity.Property(e => e.WorkTypeName).HasMaxLength(50);
        });

        modelBuilder.Entity<EventBatch>(entity =>
        {
            entity.HasKey(e => e.BatchId);

            entity.ToTable("EventBatch");

            entity.Property(e => e.BatchId).HasColumnName("BatchID");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.EventDateTimeEnd).HasColumnType("datetime");
            entity.Property(e => e.EventDateTimeStar).HasColumnType("datetime");
            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.LastModifiedAt).HasColumnType("datetime");
            entity.Property(e => e.Recurrence).HasMaxLength(50);
            entity.Property(e => e.RegistrationDateEnd).HasColumnType("datetime");
            entity.Property(e => e.RegistrationDateStar).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.EventBatchCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EventBatch_CreatedBy");

            entity.HasOne(d => d.Event).WithMany(p => p.EventBatches)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EventBatch_Event");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.EventBatchLastModifiedByNavigations)
                .HasForeignKey(d => d.LastModifiedBy)
                .HasConstraintName("FK_EventBatch_LastModifiedBy");

            entity.HasOne(d => d.StatusNavigation).WithMany(p => p.EventBatches)
                .HasForeignKey(d => d.Status)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EventBatch_Status");
        });

        modelBuilder.Entity<EventCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__EventCat__19093A2B3EF387DF");

            entity.ToTable("EventCategory");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasMaxLength(100);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedAt).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.EventCategoryCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EventCategory_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.EventCategoryLastModifiedByNavigations)
                .HasForeignKey(d => d.LastModifiedBy)
                .HasConstraintName("FK_EventCategory_LastModifiedBy");
        });

        modelBuilder.Entity<EventDetail>(entity =>
        {
            entity.HasKey(e => e.EventId);

            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.ContactPersonId).HasColumnName("ContactPersonID");
            entity.Property(e => e.ContactPhone).HasMaxLength(20);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.EventLocation).HasMaxLength(200);
            entity.Property(e => e.EventName).HasMaxLength(100);
            entity.Property(e => e.LastModifiedAt).HasColumnType("datetime");
            entity.Property(e => e.Organizer).HasMaxLength(100);
            entity.Property(e => e.TargetAudience).HasMaxLength(100);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 0)");

            entity.HasOne(d => d.Category).WithMany(p => p.EventDetails)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EventDetails_Category");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.EventDetailCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EventDetails_CreatedBy");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.EventDetailLastModifiedByNavigations)
                .HasForeignKey(d => d.LastModifiedBy)
                .HasConstraintName("FK_EventDetails_LastModifiedBy");

            entity.HasOne(d => d.StatusNavigation).WithMany(p => p.EventDetails)
                .HasForeignKey(d => d.Status)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EventDetails_Status");
        });

        modelBuilder.Entity<EventPhoto>(entity =>
        {
            entity.HasKey(e => e.PhotoId).HasName("PK__EventPho__21B7B5820E483EF2");

            entity.Property(e => e.PhotoId).HasColumnName("PhotoID");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.Photopath)
                .HasMaxLength(50)
                .HasColumnName("photopath");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.EventPhotos)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EventPhotos_CreatedBy");

            entity.HasOne(d => d.Event).WithMany(p => p.EventPhotos)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EventPhotos_Event");
        });

        modelBuilder.Entity<EventRecord>(entity =>
        {
            entity.HasKey(e => e.EventRecordId).HasName("PK__EventRec__1F2B7B8FD333A7B3");

            entity.Property(e => e.EventRecordId).HasColumnName("EventRecordID");
            entity.Property(e => e.BatchId).HasColumnName("BatchID");
            entity.Property(e => e.Content).HasMaxLength(2000);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.InternalRemarks).HasMaxLength(500);
            entity.Property(e => e.LastModifiedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Batch).WithMany(p => p.EventRecords)
                .HasForeignKey(d => d.BatchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EventRecords_Batch");

            entity.HasOne(d => d.StatusNavigation).WithMany(p => p.EventRecords)
                .HasForeignKey(d => d.Status)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EventReco__Statu__76969D2E");
        });

        modelBuilder.Entity<EventRecordPhoto>(entity =>
        {
            entity.HasKey(e => e.PhotoId).HasName("PK__EventRec__21B7B582453A762E");

            entity.Property(e => e.PhotoId).HasColumnName("PhotoID");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.EventRecordId).HasColumnName("EventRecordID");
            entity.Property(e => e.Photopath)
                .HasMaxLength(50)
                .HasColumnName("photopath");

            entity.HasOne(d => d.EventRecord).WithMany(p => p.EventRecordPhotos)
                .HasForeignKey(d => d.EventRecordId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EventReco__Event__797309D9");
        });

        modelBuilder.Entity<EventStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__EventSta__C8EE2043C9C0F637");

            entity.ToTable("EventStatus");

            entity.Property(e => e.StatusId)
                .ValueGeneratedNever()
                .HasColumnName("StatusID");
            entity.Property(e => e.StatusCategory).HasMaxLength(50);
            entity.Property(e => e.StatusName).HasMaxLength(50);
        });

        modelBuilder.Entity<MedicalHistory>(entity =>
        {
            entity.HasKey(e => e.MedicalRecordId).HasName("PK__MedicalH__4411BBC27C094512");

            entity.ToTable("MedicalHistory");

            entity.Property(e => e.MedicalRecordId).HasColumnName("MedicalRecordID");
            entity.Property(e => e.MedicalConditionName).HasMaxLength(50);
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
        });

        modelBuilder.Entity<MedicationRecord>(entity =>
        {
            entity.HasKey(e => e.MedicationId).HasName("PK__Medicati__62EC1ADA3993D0F3");

            entity.ToTable("MedicationRecord");

            entity.Property(e => e.MedicationId).HasColumnName("MedicationID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Dosage).HasMaxLength(10);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.MedicationName).HasMaxLength(50);
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.ToTable("Member");

            entity.HasIndex(e => e.Username, "UQ__Member__536C85E477CD74FB").IsUnique();

            entity.HasIndex(e => e.Idnumber, "UQ__Member__564DB08AA5ADE9A9").IsUnique();

            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.Account).HasMaxLength(50);
            entity.Property(e => e.City).HasMaxLength(200);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DietaryHabit).HasMaxLength(50);
            entity.Property(e => e.District).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.ExternalId).HasMaxLength(100);
            entity.Property(e => e.Gender).HasMaxLength(5);
            entity.Property(e => e.Height).HasColumnType("decimal(4, 1)");
            entity.Property(e => e.Idnumber)
                .HasMaxLength(10)
                .HasColumnName("IDNumber");
            entity.Property(e => e.LoginProvider).HasMaxLength(20);
            entity.Property(e => e.MedicalHistory).HasMaxLength(50);
            entity.Property(e => e.Mobility).HasMaxLength(10);
            entity.Property(e => e.Name).HasMaxLength(10);
            entity.Property(e => e.Photo).HasMaxLength(500);
            entity.Property(e => e.ResidesInCareHome).HasDefaultValue(true);
            entity.Property(e => e.RoadAddress).HasMaxLength(200);
            entity.Property(e => e.Role).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(20);
            entity.Property(e => e.Weight).HasColumnType("decimal(4, 1)");
        });

        modelBuilder.Entity<PasswordResetRecord>(entity =>
        {
            entity.HasKey(e => e.ResetId).HasName("PK__Password__783CF7ADBD3054D1");

            entity.ToTable("PasswordResetRecord");

            entity.Property(e => e.ResetId).HasColumnName("ResetID");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.SentDateTime).HasColumnType("datetime");
            entity.Property(e => e.VerificationCode).HasMaxLength(50);
        });

        modelBuilder.Entity<RegistrationDetail>(entity =>
        {
            entity.HasKey(e => e.RegistrationId).HasName("PK__Registra__6EF5883083C5EE8A");

            entity.Property(e => e.RegistrationId).HasColumnName("RegistrationID");
            entity.Property(e => e.AmountDue).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.EventBatchId).HasColumnName("EventBatchID");
            entity.Property(e => e.InternalRemarks).HasMaxLength(500);
            entity.Property(e => e.LastModifiedAt).HasColumnType("datetime");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.RegistrationDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.CurrentStatusNavigation).WithMany(p => p.RegistrationDetailCurrentStatusNavigations)
                .HasForeignKey(d => d.CurrentStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RegistrationDetails_CurrentStatus");

            entity.HasOne(d => d.EventBatch).WithMany(p => p.RegistrationDetails)
                .HasForeignKey(d => d.EventBatchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RegistrationDetails_EventBatch");

            entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.RegistrationDetails)
                .HasForeignKey(d => d.LastModifiedBy)
                .HasConstraintName("FK_RegistrationDetails_LastModifiedBy");

            entity.HasOne(d => d.PaymentStatusNavigation).WithMany(p => p.RegistrationDetailPaymentStatusNavigations)
                .HasForeignKey(d => d.PaymentStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RegistrationDetails_PaymentStatus");
        });

        modelBuilder.Entity<RegistrationParticipant>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.CompanionId).HasColumnName("CompanionID");
            entity.Property(e => e.ContactPhone).HasMaxLength(20);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.EmergencyContactName).HasMaxLength(20);
            entity.Property(e => e.EmergencyContactPhone).HasMaxLength(20);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.InternalRemarks).HasMaxLength(500);
            entity.Property(e => e.LastModifiedAt).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(20);
            entity.Property(e => e.NationalId)
                .HasMaxLength(10)
                .HasColumnName("NationalID");
            entity.Property(e => e.OtherRemarks).HasMaxLength(500);
            entity.Property(e => e.RegistrationId).HasColumnName("RegistrationID");

            entity.HasOne(d => d.Registration).WithMany()
                .HasForeignKey(d => d.RegistrationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RegistrationParticipants_Registration");

            entity.HasOne(d => d.StatusNavigation).WithMany()
                .HasForeignKey(d => d.Status)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RegistrationParticipants_Status");
        });

        modelBuilder.Entity<RoomBedTable>(entity =>
        {
            entity.HasKey(e => e.BedId);

            entity.ToTable("RoomBedTable");

            entity.Property(e => e.BedId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("BedID");
            entity.Property(e => e.CareType).HasMaxLength(50);
            entity.Property(e => e.LeaveReason).HasMaxLength(255);
            entity.Property(e => e.Remarks).HasMaxLength(255);
            entity.Property(e => e.RoomNumber)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.RoomNumberNavigation).WithMany(p => p.RoomBedTables)
                .HasForeignKey(d => d.RoomNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoomBedTable_RoomTable");
        });

        modelBuilder.Entity<RoomBillingDetailTable>(entity =>
        {
            entity.HasKey(e => e.DetailId);

            entity.ToTable("RoomBillingDetailTable");

            entity.Property(e => e.DetailId)
                .HasMaxLength(50)
                .HasColumnName("DetailID");
            entity.Property(e => e.BillingAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.BillingItem).HasMaxLength(100);
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
        });

        modelBuilder.Entity<RoomBillingRecordTable>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RoomBillingRecordTable");

            entity.Property(e => e.BedId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("BedID");
            entity.Property(e => e.BillingId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BillingID");
            entity.Property(e => e.DetailId)
                .HasMaxLength(50)
                .HasColumnName("DetailID");

            entity.HasOne(d => d.Bed).WithMany()
                .HasForeignKey(d => d.BedId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoomBillingRecordTable_RoomBedTable1");

            entity.HasOne(d => d.Detail).WithMany()
                .HasForeignKey(d => d.DetailId)
                .HasConstraintName("FK_RoomBillingRecordTable_RoomBillingDetailTable1");
        });

        modelBuilder.Entity<RoomItemRequestTable>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RoomItemRequestTable");

            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Remarks).HasMaxLength(255);
            entity.Property(e => e.StoreProductId).HasColumnName("StoreProductID");
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Member).WithMany()
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoomItemRequestTable_Member");

            entity.HasOne(d => d.StoreProduct).WithMany()
                .HasForeignKey(d => d.StoreProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoomItemRequestTable_StoreProducts");
        });

        modelBuilder.Entity<RoomTable>(entity =>
        {
            entity.HasKey(e => e.RoomNumber);

            entity.ToTable("RoomTable");

            entity.Property(e => e.RoomNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ImagePath).HasMaxLength(50);
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.RoomName).HasMaxLength(100);
            entity.Property(e => e.RoomPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Member).WithMany(p => p.RoomTables)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK_RoomTable_Member");
        });

        modelBuilder.Entity<ShopCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__19093A2BF25D0914");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasMaxLength(15);
            entity.Property(e => e.Description).HasColumnType("ntext");
            entity.Property(e => e.Picture).HasColumnType("image");
        });

        modelBuilder.Entity<ShopOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BAF280F8ADA");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.BuyerName).HasMaxLength(40);
            entity.Property(e => e.CustomerId)
                .HasMaxLength(10)
                .HasColumnName("CustomerID");
            entity.Property(e => e.DeliveryAddress).HasMaxLength(200);
            entity.Property(e => e.DeliveryMethod).HasMaxLength(100);
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(50)
                .HasColumnName("EmployeeID");
            entity.Property(e => e.InvoiceInMethod).HasMaxLength(100);
            entity.Property(e => e.InvoiceTax).HasMaxLength(100);
            entity.Property(e => e.InvoiceTitle).HasMaxLength(100);
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.Note).HasMaxLength(300);
            entity.Property(e => e.OrderTime).HasColumnType("datetime");
            entity.Property(e => e.PaymentMethod).HasMaxLength(100);
            entity.Property(e => e.ReceiverName).HasMaxLength(100);
            entity.Property(e => e.ReceiverPhone).HasMaxLength(100);

            entity.HasOne(d => d.Member).WithMany(p => p.ShopOrders)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK_ShopOrders_Member");
        });

        modelBuilder.Entity<ShopOrderDetail>(entity =>
        {
            entity.HasKey(e => e.DetailId).HasName("PK__ShopOrde__135C314D87AC1AEB");

            entity.Property(e => e.DetailId).HasColumnName("DetailID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ProductName).HasMaxLength(40);

            entity.HasOne(d => d.Order).WithMany(p => p.ShopOrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ShopOrderDetails_ShopOrders");

            entity.HasOne(d => d.Product).WithMany(p => p.ShopOrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ShopOrderDetails_ShopProducts");
        });

        modelBuilder.Entity<ShopProduct>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__ShopProd__B40CC6ED1550AA6D");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.DiscountRate).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.LargePhotoPath).HasMaxLength(50);
            entity.Property(e => e.ProductName).HasMaxLength(40);
            entity.Property(e => e.Summary).HasMaxLength(200);
            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.ThumbnailPhotoPath).HasMaxLength(50);

            entity.HasOne(d => d.Category).WithMany(p => p.ShopProducts)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_ShopProducts_ShopCategories");
        });

        modelBuilder.Entity<ShopProductPhoto>(entity =>
        {
            entity.HasKey(e => e.ProductPhotoId).HasName("PK__ShopProd__82A8EF93197BBDAC");

            entity.ToTable("ShopProductPhoto");

            entity.Property(e => e.ProductPhotoId).HasColumnName("ProductPhotoID");
            entity.Property(e => e.LargePhotoFileName).HasMaxLength(50);
            entity.Property(e => e.LargePhotoPath).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ThumbnailPhotoFileName).HasMaxLength(50);
            entity.Property(e => e.ThumbnailPhotoPath).HasMaxLength(50);

            entity.HasOne(d => d.Product).WithMany(p => p.ShopProductPhotos)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ShopProductPhoto_ShopProducts");
        });

        modelBuilder.Entity<StoreProduct>(entity =>
        {
            entity.Property(e => e.StoreProductId).HasColumnName("StoreProductID");
            entity.Property(e => e.QuantityPerUnit).HasMaxLength(10);
            entity.Property(e => e.StoreProductName).HasMaxLength(50);
            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.UnitsInStock).HasColumnType("decimal(6, 2)");

            entity.HasOne(d => d.Supplier).WithMany(p => p.StoreProducts)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StoreProducts_StoreSuppliers");
        });

        modelBuilder.Entity<StoreProductsDate>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("StoreProductsDate");

            entity.Property(e => e.ExpiryDateArrivalDate).HasColumnName("ExpiryDate/ArrivalDate");
            entity.Property(e => e.RemainingStocks).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.StoreProductId).HasColumnName("StoreProductID");
        });

        modelBuilder.Entity<StorePurchasingOrder>(entity =>
        {
            entity.Property(e => e.StorePurchasingOrderId).HasColumnName("StorePurchasingOrderID");
            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
        });

        modelBuilder.Entity<StorePurchasingOrderDetail>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.QuantityIn).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.StoreProductId).HasColumnName("StoreProductID");
            entity.Property(e => e.StorePurchasingOrderId).HasColumnName("StorePurchasingOrderID");

            entity.HasOne(d => d.StorePurchasingOrder).WithMany()
                .HasForeignKey(d => d.StorePurchasingOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StorePurchasingOrderDetails_StorePurchasingOrders");
        });

        modelBuilder.Entity<StoreSalesOrder>(entity =>
        {
            entity.HasKey(e => e.SalesOrderId);

            entity.Property(e => e.SalesOrderId).HasColumnName("SalesOrderID");
            entity.Property(e => e.CustomerName).HasMaxLength(50);
        });

        modelBuilder.Entity<StoreSalesOrderDetail>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.QuantityOfSales).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.SalesOrderId).HasColumnName("SalesOrderID");
            entity.Property(e => e.StoreProductId).HasColumnName("StoreProductID");

            entity.HasOne(d => d.SalesOrder).WithMany()
                .HasForeignKey(d => d.SalesOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StoreSalesOrderDetails_StoreSalesOrders");
        });

        modelBuilder.Entity<StoreSupplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId);

            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.Contact).HasMaxLength(20);
            entity.Property(e => e.ContactNumber).HasMaxLength(20);
            entity.Property(e => e.SupplierGui)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SupplierGUI");
            entity.Property(e => e.SupplierName).HasMaxLength(50);
        });

        modelBuilder.Entity<SupportMessage>(entity =>
        {
            entity.HasKey(e => e.MessageId).HasName("PK__SupportM__C87C0C9C4AFB0409");

            entity.ToTable("SupportMessage");

            entity.Property(e => e.SenderType).HasMaxLength(20);
            entity.Property(e => e.SentAt).HasColumnType("datetime");

            entity.HasOne(d => d.Ticket).WithMany(p => p.SupportMessages)
                .HasForeignKey(d => d.TicketId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SupportMessage_SupportTicket");
        });

        modelBuilder.Entity<SupportTicket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("PK__SupportT__712CC607DC1066D7");

            entity.ToTable("SupportTicket");

            entity.Property(e => e.AssignedEmployeeId).HasColumnName("AssignedEmployeeID");
            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.ClosedAt).HasColumnType("datetime");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.PriorityLevel).HasMaxLength(20);
            entity.Property(e => e.ResolvedAt).HasColumnType("datetime");
            entity.Property(e => e.TicketStatus).HasMaxLength(20);
            entity.Property(e => e.Title).HasMaxLength(50);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<TSearchLog>(entity =>
        {
            entity.HasKey(e => e.SearchId).HasName("PK__tSearchL__21C535F49586DB9C");

            entity.ToTable("tSearchLog");

            entity.Property(e => e.Keyword).HasMaxLength(100);
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.SearchTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserIp)
                .HasMaxLength(50)
                .HasColumnName("UserIP");

            entity.HasOne(d => d.Member).WithMany(p => p.TSearchLogs)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tSearchLo__Membe__06ED0088");
        });

        modelBuilder.Entity<TransferOrder>(entity =>
        {
            entity.Property(e => e.TransferOrderId).HasColumnName("TransferOrderID");
        });

        modelBuilder.Entity<TransferOrderDetail>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.QuantityOfTransfer).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.StoreProductId).HasColumnName("StoreProductID");
            entity.Property(e => e.TransferOrderId).HasColumnName("TransferOrderID");

            entity.HasOne(d => d.TransferOrder).WithMany()
                .HasForeignKey(d => d.TransferOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TransferOrderDetails_TransferOrders");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
