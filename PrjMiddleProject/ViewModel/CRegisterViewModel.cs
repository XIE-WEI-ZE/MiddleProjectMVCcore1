using System.ComponentModel.DataAnnotations;

namespace prjCareHomeSystem.ViewModels
{
    public class CRegisterViewModel
    {
        [Required(ErrorMessage = "請輸入姓名")]
        [Display(Name = "姓名")]
        public string Name { get; set; }

        [Required(ErrorMessage = "請輸入帳號")]
        [Display(Name = "帳號")]
        public string Account { get; set; }

        [Required(ErrorMessage = "請輸入 Email")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "請輸入密碼")]
        [DataType(DataType.Password)]
        [Display(Name = "密碼")]
        public string Password { get; set; }

        [Required(ErrorMessage = "請再次輸入密碼")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "兩次密碼不一致")]
        [Display(Name = "確認密碼")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "角色")]
        public string Role { get; set; } = "住戶";

        [Display(Name = "性別")]
        public string Gender { get; set; }

        
        [Display(Name = "出生年")]
        public int? BirthYear { get; set; }

        [Display(Name = "出生月")]
        public int? BirthMonth { get; set; }

        [Display(Name = "出生日")]
        public int? BirthDay { get; set; }

        
        public DateOnly? BirthDate =>
            BirthYear.HasValue && BirthMonth.HasValue && BirthDay.HasValue
            ? new DateOnly(BirthYear.Value, BirthMonth.Value, BirthDay.Value)
            : null;

        [Display(Name = "縣市")]
        public string City { get; set; }

        [Display(Name = "鄉鎮區")]
        public string District { get; set; }

        [Display(Name = "路段地址")]
        public string RoadAddress { get; set; }

        public string FullAddress => $"{City}{District}{RoadAddress}";
    }
}
