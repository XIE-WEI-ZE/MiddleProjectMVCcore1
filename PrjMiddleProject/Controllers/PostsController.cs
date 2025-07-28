using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrjMiddleProject.Models;
using PrjMiddleProject.ViewModel;

namespace PrjMiddleProject.Controllers
{
    public class PostsController : Controller
    {

        private readonly NursingHomeContext _context;

        public PostsController(NursingHomeContext context)
        {
            _context = context;
        }

        public IActionResult List(String txtKeyword)
        {
            var posts = string.IsNullOrEmpty(txtKeyword)
                ? _context.CommunityPosts.OrderByDescending(m => m.UpdatedAt).ToList()
                : _context.CommunityPosts
                .Where(p => p.PostTitle.Contains(txtKeyword) || p.PostContent.Contains(txtKeyword))
                .OrderByDescending(m => m.UpdatedAt)
                .ToList();

            // 取得所有相關會員的名稱字典：MemberId => MemberName
            var memberIds = posts.Select(p => p.MemberId).Distinct().ToList();

            var memberDict = _context.Members
                .Where(m => memberIds.Contains(m.MemberId))
                .ToDictionary(m => m.MemberId, m => m.Name);  // 假設會員名稱欄位叫 Name

            ViewBag.MemberNames = memberDict;

            return View(posts);
        }

        // 新增文章
        public IActionResult Create()
        {
            var members = _context.Members
                .OrderBy(m => m.MemberId)
                .Select(m => new
                {
                    m.MemberId,
                    DisplayText = m.MemberId + " (" + m.Name + ")"
                }).ToList();

            ViewBag.MemberId = new SelectList(members, "MemberId", "DisplayText");

            return PartialView("_CreatePartial");
        }

        // 處理新增文章表單提交
        [HttpPost]
        public IActionResult Create(CommunityPost p)
        {
            // 手動把 PostStatuses 設定，並從 ModelState 移除 PostStatuses 驗證錯誤
            p.PostStatuses = "已發布";

            // 清除 ModelState 內 PostStatuses 的錯誤，避免驗證失敗
            ModelState.Remove(nameof(p.PostStatuses));

            if (ModelState.IsValid)
            {
                p.CreatedAt = DateTime.Now;
                p.UpdatedAt = DateTime.Now;

                _context.CommunityPosts.Add(p);
                _context.SaveChanges();

                return Json(new { success = true });
            }

            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            return Json(new { success = false, errors = errors });
        }

        // 軟刪除
        [HttpPost]
        public IActionResult ToggleStatus(int? id)
        {
            var post = _context.CommunityPosts.FirstOrDefault(p => p.PostId == id);
            if (post == null)
            {
                return NotFound();
            }

            // 如果已發布，就改為已刪除；反之則恢復為已發布
            post.PostStatuses = post.PostStatuses == "已發布" ? "已刪除" : "已發布";
            post.UpdatedAt = DateTime.Now;
            _context.SaveChanges();

            return Json(new { success = true, newStatus = post.PostStatuses });
        }

        // 編輯
        public IActionResult Edit(int? id)
        {
            var post = _context.CommunityPosts.FirstOrDefault(p => p.PostId == id);
            if (post == null) return NotFound();

            // 檢查是否有回覆，並用 ViewBag 傳遞
            bool hasReplies = false;
            try
            {
                // 使用 Set<T>() 方法來避免 DbSet 名稱問題
                hasReplies = _context.Set<CommunityReply>().Any(r => r.PostId == id);
            }
            catch
            {
                // 如果查詢失敗，就設為 false
                hasReplies = false;
            }

            ViewBag.HasReplies = hasReplies;

            return PartialView("_EditPartial", post); // 傳入要編輯的文章資料
        }

        // 更新資料
        [HttpPost]
        public IActionResult Edit(CommunityPost model)
        {
            var post = _context.CommunityPosts.FirstOrDefault(p => p.PostId == model.PostId);
            if (post == null) return NotFound();

            post.PostTitle = model.PostTitle;
            post.PostContent = model.PostContent;
            post.UpdatedAt = DateTime.Now;

            _context.SaveChanges();

            return Json(new { success = true }); // 回傳成功訊息
        }

        // 查看回覆按鈕
        public IActionResult ViewReplies(int? postId)
        {
            if (postId == null)
                return NotFound();

            var post = _context.CommunityPosts.FirstOrDefault(p => p.PostId == postId);
            if (post == null)
                return NotFound();

            // 撈出回覆
            var replies = _context.CommunityReplys
                            .Where(r => r.PostId == postId)
                            .OrderBy(r => r.RepliedAt)
                            .ToList();

            // 取得所有回覆者 MemberId 並撈出對應會員名稱
            var memberIds = replies.Select(r => r.MemberId).Distinct().ToList();

            var memberNamesMap = _context.Members
                                    .Where(m => memberIds.Contains(m.MemberId))
                                    .ToDictionary(m => m.MemberId, m => m.Name);

            var viewModel = new CReplyViewModel
            {
                Post = post,
                Replies = replies,
                MemberNamesMap = memberNamesMap
            };

            return PartialView("_ViewRepliesPartial", viewModel);
        }

        // GET: 載入回覆表單
        [HttpGet]
        [Route("Posts/CreateReply/{id}")]
        public ActionResult CreateReply(int id)
        {

            var members = _context.Members
                .OrderBy(m => m.MemberId)
                .Select(m => new
                {
                    m.MemberId,
                    DisplayText = m.MemberId + " (" + m.Name + ")"
                }).ToList();

            ViewBag.MemberId = new SelectList(members, "MemberId", "DisplayText");

            var post = _context.CommunityPosts.FirstOrDefault(p => p.PostId == id);
            if (post == null)
            {
                return NotFound(); // 沒有文章就返回 404
            }

            var vm = new CAddReplyFormViewModel
            {
                PostId = post.PostId
            };

            return PartialView("_CreateReply", vm);
        }

        // POST: 處理表單提交
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Posts/CreateReply")]
        public JsonResult CreateReply(CAddReplyFormViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return Json(new { success = false, errors });
            }

            var reply = new CommunityReply
            {
                PostId = vm.PostId,
                MemberId = vm.MemberId,
                ReplyContent = vm.ReplyContent,
                RepliedAt = DateTime.Now,
                ReplyStatuses = "已發布"
            };

            _context.CommunityReplys.Add(reply);
            _context.SaveChanges();

            return Json(new { success = true });
        }

    }
}
