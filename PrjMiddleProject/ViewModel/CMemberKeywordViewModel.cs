namespace PrjMiddleProject.ViewModels
{
    public class CMemberKeywordViewModel
    {
        public string txtKeyword { get; set; }
        public List<CMemberViewModel> Members { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
