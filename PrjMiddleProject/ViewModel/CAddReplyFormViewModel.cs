
using System.ComponentModel.DataAnnotations;

namespace PrjMiddleProject.ViewModel
{
    public class CAddReplyFormViewModel // 用於新增回覆表單的輸入
    {
        public int PostId { get; set; }

        [Display(Name = "會員")]
        [Required(ErrorMessage = "請選擇會員。")]
        [Range(1, int.MaxValue, ErrorMessage = "請選擇一個有效的會員。")] // 確保 MemberId 有效
        public int MemberId { get; set; }

        [Display(Name = "回覆內容")]
        [Required(ErrorMessage = "回覆內容不可為空。")]
        [StringLength(500, ErrorMessage = "回覆內容不能超過 500 個字。")]
        public string ReplyContent { get; set; }
    }
}