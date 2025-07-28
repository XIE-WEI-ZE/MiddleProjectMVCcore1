namespace PrjMiddleProject.ViewModels
{
    public class CPaginationInfo
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 5;
        public string ActionName { get; set; } = "List";
        public string? Keyword { get; set; }
    }
}
