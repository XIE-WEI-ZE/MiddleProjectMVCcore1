using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrjMiddleProject.Models;

public partial class Employee
{
    [Display(Name = "員工編號")]
    public int EmployeeId { get; set; }

    [Required(ErrorMessage = "請選擇在職狀態")]
    [Display(Name = "是否在職")]
    public string? EmploymentStatus { get; set; }

    [Required(ErrorMessage = "請選擇是否為系統管理員")]
    [Display(Name = "是否為系統管理員")]
    public bool? IsAdmin { get; set; }

    [Required(ErrorMessage = "請選擇是否為主管")]
    [Display(Name = "是否為主管")]
    public bool? IsSupervisor { get; set; }

    [Required(ErrorMessage = "請輸入身分證字號")]
    [Display(Name = "身分證字號")]
    public string? EmployeeIdnumber { get; set; }
    
    [Required(ErrorMessage = "請選擇部門")]
    [Display(Name = "部門名稱")]
    public int? DepartmentId { get; set; }

    [Required(ErrorMessage = "請選擇職位")]
    [Display(Name = "職位名稱")]
    public int? JobTitleId { get; set; }

    [Required(ErrorMessage = "請輸入姓名")]
    [Display(Name = "姓名")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "請選擇性別")]
    [Display(Name = "性別")]
    public string? Gender { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "出生日期")]
    public DateTime? DateOfBirth { get; set; }

    [Required(ErrorMessage = "請輸入行動電話")]
    [Display(Name = "行動電話")]
    public string? MobileNumber { get; set; }

    [Required(ErrorMessage = "請輸入電子郵件")]
    [EmailAddress(ErrorMessage = "電子郵件格式不正確")]
    [Display(Name = "電子郵件")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "請選擇到職日期")]
    [DataType(DataType.Date)]
    [Display(Name = "到職日期")]
    public DateTime? DateOfHire { get; set; }

    [Required(ErrorMessage = "請輸入現居地址")]
    [Display(Name = "現居地址")]
    public string? CurrentAddress { get; set; }

    [Required(ErrorMessage = "請輸入戶籍地址")]
    [Display(Name = "戶籍地址")]
    public string? RegisteredAddress { get; set; }

    [Required(ErrorMessage = "請選擇教育程度")]
    [Display(Name = "教育程度")]
    public string? EducationLevel { get; set; }

    [Display(Name = "年資")]
    [ReadOnly(true)]
    public string? YearsOfService { get; set; }

    [Required(ErrorMessage = "請選擇身高")]
    [Display(Name = "身高")]
    public decimal? Height { get; set; }

    [Required(ErrorMessage = "請選擇體重")]
    [Display(Name = "體重")]
    public decimal? Weight { get; set; }

    [Required(ErrorMessage = "請勾選良民證")]
    [Display(Name = "是否具有良民證")]
    public bool? PoliceClearanceCertificate { get; set; }

    [Required(ErrorMessage = "請輸入緊急聯絡人姓名")]
    [Display(Name = "緊急聯絡人姓名")]
    public string? EmergencyContactPerson { get; set; }

    [Required(ErrorMessage = "請選擇與緊急聯絡人關係")]
    [Display(Name = "與緊急聯絡人關係")]
    public string? EmergencyContactRelationship { get; set; }

    [Required(ErrorMessage = "請輸入緊急聯絡人電話")]
    [Display(Name = "緊急聯絡人電話")]
    public string? EmergencyContactPhone { get; set; }

    [Required(ErrorMessage = "請輸入薪資帳戶號碼")]
    [Display(Name = "薪資帳戶號碼")]
    public string? PayrollBankAccount { get; set; }

    [Display(Name = "大頭照路徑")]
    public string? Photopath { get; set; }

    [NotMapped]
    public IFormFile? PhotoFile { get; set; }

    // 導覽屬性
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
