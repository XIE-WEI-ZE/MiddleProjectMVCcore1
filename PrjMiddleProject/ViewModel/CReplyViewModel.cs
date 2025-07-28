using PrjMiddleProject.Models;
using System.Collections.Generic;

namespace PrjMiddleProject.ViewModel
{
    public class CReplyViewModel // 用於顯示文章和回覆列表
    {
        public int PostId { get; set; }
        public string Content { get; set; }
        public CommunityPost Post { get; set; }

        public List<CommunityReply> Replies { get; set; } = new List<CommunityReply>();

        // 用來存 MemberId 對應 MemberName
        public Dictionary<int, string> MemberNamesMap { get; set; } = new Dictionary<int, string>();


    }
}
