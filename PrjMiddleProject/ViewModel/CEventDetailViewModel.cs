using PrjMiddleProject.Models;
using System.ComponentModel.DataAnnotations;

namespace PrjMiddleProject.ViewModel
{
    public class CEventDetailViewModel : EventDetail
    {

        public virtual EventCategory Category { get; set; }
        public virtual Employee ContactPerson { get; set; }
        public string CategoryName { get; set; }
        public string ContactPersonName { get; set; }

        public int EventId { get; set; }

        [Required(ErrorMessage = "活動名稱為必填欄位")]
        public string EventName { get; set; } = null!;
        [Required(ErrorMessage = "主辦單位為必填欄位")]
        public string Organizer { get; set; } = null!;
        [Required(ErrorMessage = "活動對象為必填欄位")]
        public string TargetAudience { get; set; } = null!;

        public bool RequiresFamilyInsurance { get; set; }

        public int CategoryId { get; set; }

        public int Status { get; set; }
        [Required(ErrorMessage = "請選擇聯繫窗口")]
        public int ContactPersonId { get; set; }
        [Required(ErrorMessage = "連絡電話為必填欄位")]
        public string ContactPhone { get; set; } = null!;
        [Required(ErrorMessage = "活動地點為必填欄位")]
        public string EventLocation { get; set; } = null!;

        public int? Quota { get; set; }
        [Required(ErrorMessage = "活動內容為必填欄位")]
        public string Description { get; set; } = null!;

        public string? MedicalAid { get; set; }

        public bool IsPaid { get; set; }

        public decimal? TotalAmount { get; set; }

        public DateTime CreatedAt { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? LastModifiedAt { get; set; }

        public int? LastModifiedBy { get; set; }


        public virtual Employee CreatedByNavigation { get; set; } = null!;

        public virtual ICollection<EventBatch> EventBatches { get; set; } = new List<EventBatch>();

        public virtual ICollection<EventPhoto> EventPhotos { get; set; } = new List<EventPhoto>();

        public virtual Employee? LastModifiedByNavigation { get; set; }

        public virtual EventStatus StatusNavigation { get; set; } = null!;



    }
}
