namespace PrjMiddleProject.ViewModel
{
    public class CCommunityPostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PostDate { get; set; }

        // 額外欄位：會員名稱
        public string MemberName { get; set; }
    }
}
