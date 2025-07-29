namespace PrjMiddleProject.ViewModel
{
    public class CEmployeeDetailsViewModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeIDNumber { get; set; }     // 新增：員工代碼
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfHire { get; set; }
        public string YearsOfService { get; set; }
        public string EmploymentStatus { get; set; }

        public bool? IsAdmin { get; set; }               // 新增：是否管理員
        public bool? IsSupervisor { get; set; }          // 新增：是否主管

        public string DepartmentName { get; set; }
        public string JobTitleName { get; set; }

        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string CurrentAddress { get; set; }
        public string RegisteredAddress { get; set; }
        public string EducationLevel { get; set; }

        public decimal? Height { get; set; }
        public decimal? Weight { get; set; }
        public bool? PoliceClearanceCertificate { get; set; }

        public string EmergencyContactPerson { get; set; }
        public string EmergencyContactRelationship { get; set; }
        public string EmergencyContactPhone { get; set; }

        public string PayrollBankAccount { get; set; }
        public string Photopath { get; set; }
    }
}
