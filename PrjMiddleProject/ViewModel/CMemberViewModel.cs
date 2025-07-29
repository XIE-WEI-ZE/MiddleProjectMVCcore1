using System.ComponentModel.DataAnnotations;

namespace PrjMiddleProject.ViewModels
{
    public class CMemberViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Username { get; set; }

        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "密碼長度至少為 6 碼")]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "確認密碼")]
        [Compare("Password", ErrorMessage = "密碼與確認密碼不一致")]
        public string? ConfirmPassword { get; set; }

        [StringLength(10, ErrorMessage = "IDNumber 最多 10 碼")]
        [Required]
        public string IDNumber { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public bool? ResidesInCareHome { get; set; }

        public string Gender { get; set; }

        [Display(Name = "生日")]
        [DataType(DataType.Date)]
        public DateTime? Birthday { get; set; }

        public bool IsEnabled { get; set; }
    }
}
