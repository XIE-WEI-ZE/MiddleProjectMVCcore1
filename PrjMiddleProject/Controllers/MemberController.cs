using Microsoft.AspNetCore.Mvc;
using PrjMiddleProject.Models;
using PrjMiddleProject.ViewModels;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace PrjMiddleProject.Controllers
{
    public class MemberController : Controller
    {
        public IActionResult List(string txtKeyword, int page = 1)
        {
            int pageSize = 10;
            NursingHomeContext db = new NursingHomeContext();

            var query = db.Members.AsQueryable();

            // 搜尋條件（模糊）
            if (!string.IsNullOrEmpty(txtKeyword))
            {
                query = query.Where(m =>
                    (m.Name != null && m.Name.Contains(txtKeyword)) ||
                    (m.Idnumber != null && m.Idnumber.Contains(txtKeyword)) ||
                    (m.Account != null && m.Account.Contains(txtKeyword))
                );
            }

            // 總筆數與總頁數
            int totalCount = query.Count();
            int totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            // 分頁查詢資料
            var result = query
                .OrderBy(m => m.MemberId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(m => new CMemberViewModel
                {
                    Id = m.MemberId,
                    Name = m.Name,
                    IDNumber = m.Idnumber,
                    ResidesInCareHome = m.ResidesInCareHome,
                    Gender = m.Gender,
                    Birthday = m.BirthDate.HasValue ? m.BirthDate.Value.ToDateTime(new TimeOnly(0, 0)) : null,
                    IsEnabled = m.Role != "Banned"
                }).ToList();

            // 將資料包進 ViewModel 傳給 View
            var vm = new CMemberKeywordViewModel
            {
                txtKeyword = txtKeyword,
                Members = result,
                CurrentPage = page,
                TotalPages = totalPages
            };

            return View(vm);
        }



        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CMemberViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            NursingHomeContext db = new NursingHomeContext();

            if (string.IsNullOrEmpty(vm.Account))
            {
                ModelState.AddModelError("Account", "帳號不可為空");
                return View(vm);
            }

            if (db.Members.Any(m => m.Account == vm.Account))
            {
                ModelState.AddModelError("Account", "此帳號已存在");
                return View(vm);
            }

            
            string salt = Guid.NewGuid().ToString();
            string password = "123456"; 
            string hashPwd = HashPassword(password, salt);

            Member m = new Member
            {
                Name = vm.Name,
                Account = vm.Account,
                Email = vm.Email,
                Gender = vm.Gender,
                BirthDate = vm.Birthday.HasValue ? DateOnly.FromDateTime(vm.Birthday.Value) : null,
                Role = vm.IsEnabled ? "Member" : "Banned",
                CreatedDate = DateTime.Now,
                Username = vm.Account,
                Password = hashPwd,
                PasswordSalt = salt,
                IsTempPassword = true,
                Idnumber = vm.IDNumber
            };

            db.Members.Add(m);
            db.SaveChanges();

            return RedirectToAction("List");
        }



        private string HashPassword(string password, string salt) { 
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password+salt);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("List");

            NursingHomeContext db = new NursingHomeContext();
            var member = db.Members.FirstOrDefault(m => m.MemberId == id.Value);

            if (member == null)
                return RedirectToAction("List");

            var vm = new CMemberViewModel
            {
                Id = member.MemberId,
                Name = member.Name,
               
                Email = member.Email,
                Gender = member.Gender,
                Birthday = member.BirthDate?.ToDateTime(new TimeOnly(0, 0)),
                IDNumber = member.Idnumber,
                ResidesInCareHome = member.ResidesInCareHome,
                IsEnabled = member.Role != "Banned",
                Account = member.Account
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CMemberViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            NursingHomeContext db = new NursingHomeContext();
            var member = db.Members.FirstOrDefault(m => m.MemberId == vm.Id);

            if (member == null)
            {
                ModelState.AddModelError("", "找不到會員資料");
                return View(vm);
            }

            member.Name = vm.Name;
            member.Email = vm.Email;
            member.Gender = vm.Gender;
            member.BirthDate = vm.Birthday.HasValue ? DateOnly.FromDateTime(vm.Birthday.Value) : null;
            member.Idnumber = vm.IDNumber;
            member.ResidesInCareHome = vm.ResidesInCareHome;
            member.Role = vm.IsEnabled ? "Member" : "Banned";
            member.Account = vm.Account; 

            db.SaveChanges();

            TempData["Msg"] = "會員資料更新成功！";
            return RedirectToAction("List");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult ToggleStatus([FromBody] int id)
        {
            NursingHomeContext db = new NursingHomeContext();
            var member = db.Members.FirstOrDefault(m => m.MemberId == id);

            if (member == null)
                return Json(new { success = false, message = "找不到會員資料" });

            // 切換帳號狀態
            member.Role = (member.Role == "Banned") ? "Member" : "Banned";
            db.SaveChanges();

            return Json(new
            {
                success = true,
                isEnabled = member.Role != "Banned",
                message = "帳號狀態已更新"
            });
        }




    }
}
