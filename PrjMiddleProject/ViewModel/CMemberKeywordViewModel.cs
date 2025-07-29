namespace PrjMiddleProject.ViewModels
{
    public class CMemberKeywordViewModel
    {
        // 查詢條件
        public string? txtKeyword { get; set; }
        public bool? ResidesInCareHomeFilter { get; set; }
        public bool? IsEnabledFilter { get; set; }

        // 分頁資訊
        public int Page { get; set; } = 1;
        public int CurrentPage => Page;    // 給 ViewBag 用的
        public int TotalPages { get; set; }

        // 查詢結果資料
        public List<CMemberViewModel> Members { get; set; } = new List<CMemberViewModel>();
    }
}
