using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrjMiddleProject.Models;

namespace PrjNursingHome.Controllers
{
    public class RoomTableController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly NursingHomeContext _db;

        public RoomTableController(IWebHostEnvironment env, NursingHomeContext db)
        {
            _env = env;
            _db = db;
        }

        public IActionResult List(string txtKeyword)
        {
            var datas = _db.RoomTables
                          .Where(r => string.IsNullOrEmpty(txtKeyword) ||
                                      r.RoomNumber.Contains(txtKeyword) ||
                                      r.RoomName.Contains(txtKeyword))
                          .ToList();
            return View(datas);
        }

        public IActionResult Create()
        {
            LoadMemberDropdown();
            return View();
        }

        [HttpPost]
        public IActionResult Create(RoomTable r, IFormFile photo)
        {
            if (_db.RoomTables.Any(rt => rt.RoomNumber == r.RoomNumber))
            {
                ModelState.AddModelError("RoomNumber", "此房號已存在");
                LoadMemberDropdown();
                return View(r);
            }

            if (!ModelState.IsValid)
            {
                LoadMemberDropdown();
                return View(r);
            }

            if (photo != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(photo.FileName);
                string filePath = Path.Combine(_env.WebRootPath, "images/beds", fileName);
                using var stream = new FileStream(filePath, FileMode.Create);
                photo.CopyTo(stream);
                r.ImagePath = fileName;
            }

            _db.RoomTables.Add(r);
            _db.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult Edit(string roomNumber)
        {
            if (string.IsNullOrEmpty(roomNumber))
                return RedirectToAction("List");

            var room = _db.RoomTables.FirstOrDefault(r => r.RoomNumber == roomNumber);
            if (room == null)
                return RedirectToAction("List");

            LoadMemberDropdown(room.MemberId);
            return View(room);
        }

        [HttpPost]
        public IActionResult Edit(RoomTable updateRoom, IFormFile photo)
        {
            var room = _db.RoomTables.FirstOrDefault(r => r.RoomNumber == updateRoom.RoomNumber);
            if (room == null)
                return RedirectToAction("List");

            if (_db.RoomTables.Any(rt => rt.RoomNumber == updateRoom.RoomNumber && rt.RoomNumber != room.RoomNumber))
            {
                ModelState.AddModelError("RoomNumber", "此房號已存在，請選擇其他房號");
                LoadMemberDropdown(room.MemberId);
                return View(updateRoom);
            }

            room.RoomName = updateRoom.RoomName;
            room.RoomType = updateRoom.RoomType;
            room.BedCount = updateRoom.BedCount;
            room.RoomPrice = updateRoom.RoomPrice.HasValue ? Math.Floor(updateRoom.RoomPrice.Value) : null;
            room.MemberId = updateRoom.MemberId;

            if (photo != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(photo.FileName);
                string filePath = Path.Combine(_env.WebRootPath, "images/beds", fileName);
                using var stream = new FileStream(filePath, FileMode.Create);
                photo.CopyTo(stream);
                room.ImagePath = fileName;
            }

            _db.SaveChanges();
            return RedirectToAction("List"); // 修正：保存後回到 List 頁面
        }

        [HttpPost]
        public IActionResult UploadPhoto(string roomNumber, IFormFile photo)
        {
            var room = _db.RoomTables.FirstOrDefault(r => r.RoomNumber == roomNumber);
            if (room == null)
                return Json(new { success = false, message = "房間未找到" });

            try
            {
                if (photo != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(photo.FileName);
                    string filePath = Path.Combine(_env.WebRootPath, "images/beds", fileName);
                    using var stream = new FileStream(filePath, FileMode.Create);
                    photo.CopyTo(stream);
                    room.ImagePath = fileName;
                    _db.SaveChanges();
                }
                return Json(new { success = true, imagePath = room.ImagePath });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "上傳失敗: " + ex.Message });
            }
        }

        public IActionResult Delete(string roomNumber)
        {
            if (string.IsNullOrEmpty(roomNumber))
                return RedirectToAction("List");

            var room = _db.RoomTables.FirstOrDefault(r => r.RoomNumber == roomNumber);
            if (room != null)
            {
                _db.RoomTables.Remove(room);
                _db.SaveChanges();
            }
            return RedirectToAction("List");
        }

        public IActionResult Details(string roomNumber)
        {
            if (string.IsNullOrEmpty(roomNumber))
                return Content("查無資料");

            var room = _db.RoomTables
                         .Include(r => r.Member)
                         .FirstOrDefault(r => r.RoomNumber == roomNumber);
            if (room == null)
                return Content("查無資料");

            return PartialView("_RoomDetailsPartial", room);
        }

        [HttpGet]
        public IActionResult CheckRoomNumber(string roomNumber)
        {
            bool exists = _db.RoomTables.Any(r => r.RoomNumber == roomNumber);
            return Json(new { exists = exists, message = exists ? "此房號已存在" : "" });
        }

        private void LoadMemberDropdown(int? editingMemberId = null)
        {
            var occupiedMemberIds = _db.RoomTables
                .Where(r => r.MemberId.HasValue)
                .Select(r => r.MemberId.Value)
                .ToHashSet();

            if (editingMemberId.HasValue)
                occupiedMemberIds.Remove(editingMemberId.Value);

            ViewBag.AvailableMembers = _db.Members
                .Select(m => new KeyValuePair<int, string>(m.MemberId, m.Name ?? ""))
                .ToList();

            ViewBag.OccupiedMembers = occupiedMemberIds;
        }
    }
}