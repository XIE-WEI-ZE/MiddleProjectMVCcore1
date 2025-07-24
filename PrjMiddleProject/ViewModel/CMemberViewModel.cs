using System.ComponentModel.DataAnnotations;

namespace PrjMiddleProject.ViewModels
{
    public class CMemberViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        
        public string Account { get; set; }

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
