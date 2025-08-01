using Microsoft.AspNetCore.Mvc;
using PrjMiddleProject.Models;
using PrjMiddleProject.ViewModels;
<<<<<<< Updated upstream
using System.Linq;
using System.Security.Cryptography;
using System.Text;
=======

>>>>>>> Stashed changes

namespace PrjMiddleProject.Controllers
{
    public class MemberController : Controller
    {
<<<<<<< Updated upstream
        public IActionResult List(CMemberKeywordViewModel vm)
        {
            NursingHomeContext db = new NursingHomeContext();
            IEnumerable<Member> datas = null;
            // 基礎查詢
            var query = from m in db.Members
                        select m;
            // 關鍵字搜尋
            if (!string.IsNullOrEmpty(vm.txtKeyword))
            {
                query = from m in query
                        where (m.Name ?? "").Contains(vm.txtKeyword) ||
                              (m.Idnumber ?? "").Contains(vm.txtKeyword) ||
                              (m.Username ?? "").Contains(vm.txtKeyword)
                        select m;
            }
            // 過濾條件
            if (vm.ResidesInCareHomeFilter.HasValue)
            {
                query = from m in query
                        where m.ResidesInCareHome == vm.ResidesInCareHomeFilter.Value
                        select m;
            }
            if (vm.IsEnabledFilter.HasValue)
            {
                query = from m in query
                        where (m.Role != "Banned") == vm.IsEnabledFilter.Value
                        select m;
            }
            // 分頁邏輯
            int totalCount = query.Count();
            int pageSize = 10;
            vm.TotalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            datas = query
                .OrderBy(m => m.MemberId)
                .Skip((vm.Page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            // 設定 ViewBag
            ViewBag.Keyword = vm.txtKeyword;
            ViewBag.Page = vm.Page;
            ViewBag.TotalPages = vm.TotalPages;
            ViewBag.ResidesInCareHomeFilter = vm.ResidesInCareHomeFilter;
            ViewBag.IsEnabledFilter = vm.IsEnabledFilter;
            return View(datas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CMemberViewModel vm)
        {
            NursingHomeContext db = new NursingHomeContext();
            if (!ModelState.IsValid)
                return View(vm);
            // 手動檢查密碼是否為空
            if (string.IsNullOrEmpty(vm.Password))
            {
                ModelState.AddModelError(nameof(vm.Password), "密碼為必填");
                return View(vm);
            }
            // 檢查帳號是否重複
            if (db.Members.Any(m => m.Username == vm.Username))
            {
                ModelState.AddModelError(nameof(vm.Username), "此帳號已存在");
                return View(vm);
            }
            try
            {
                string salt = Guid.NewGuid().ToString("N");
                string hashPwd = HashPassword(vm.Password, salt);

                Member m = new Member
                {
                    Name = vm.Name,
                    Username = vm.Username,
                    Email = vm.Email,
                    Gender = vm.Gender,
                    BirthDate = vm.Birthday.HasValue ? DateOnly.FromDateTime(vm.Birthday.Value) : null,
                    Role = vm.IsEnabled ? "Member" : "Banned",
                    CreatedDate = DateTime.Now,
                    Password = hashPwd,
                    PasswordSalt = salt,
                    IsTempPassword = false,
                    Idnumber = vm.IDNumber,
                    ResidesInCareHome = vm.ResidesInCareHome
                };
                db.Members.Add(m);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "儲存失敗：" + ex.Message);
                return View(vm);
            }
        }

        private string HashPassword(string password, string salt)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password + salt);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("List");

            NursingHomeContext db = new NursingHomeContext();
            Member data = db.Members.FirstOrDefault(m => m.MemberId == id);

            if (data == null)
                return RedirectToAction("List");

            return View(new CMemberViewModel
            {
                Id = data.MemberId,
                Name = data.Name,
                Email = data.Email,
                Gender = data.Gender,
                IDNumber = data.Idnumber,
                ResidesInCareHome = data.ResidesInCareHome,
                IsEnabled = data.Role != "Banned",
                Username = data.Username,
                Birthday = data.BirthDate?.ToDateTime(new TimeOnly(0, 0))
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CMemberViewModel vm)
        {
            NursingHomeContext db = new NursingHomeContext();
            Member data = db.Members.FirstOrDefault(m => m.MemberId == vm.Id);
            if (data == null)
                return RedirectToAction("List");
            try
            {
                // 檢查帳號是否與其他現有帳號重複
                if (db.Members.Any(m => m.Username == vm.Username && m.MemberId != vm.Id))
                {
                    ModelState.AddModelError(nameof(vm.Username), "此帳號已存在");
                    return View(vm);
                }
                if (!ModelState.IsValid)
                    return View(vm);
                data.Name = vm.Name;
                data.Email = vm.Email;
                data.Gender = vm.Gender;
                data.BirthDate = vm.Birthday.HasValue ? DateOnly.FromDateTime(vm.Birthday.Value) : null;
                data.Idnumber = vm.IDNumber;
                data.ResidesInCareHome = vm.ResidesInCareHome;
                data.Role = vm.IsEnabled ? "Member" : "Banned";
                data.Username = vm.Username;
                if (!string.IsNullOrEmpty(vm.Password))
                {
                    string salt = Guid.NewGuid().ToString("N");
                    string hashPwd = HashPassword(vm.Password, salt);
                    data.Password = hashPwd;
                    data.PasswordSalt = salt;
                    data.IsTempPassword = false;
                }
                db.SaveChanges();
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "儲存失敗：" + ex.Message);
                return View(vm);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ToggleStatus(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("List");
            NursingHomeContext db = new NursingHomeContext();
            var member = db.Members.FirstOrDefault(m => m.MemberId == id.Value);
            if (member == null)
                return RedirectToAction("List");
            // 切換帳號狀態
            member.Role = (member.Role == "Banned") ? "Member" : "Banned";
=======


        public IActionResult List() {
            NursingHomeContext db = new NursingHomeContext();
            IEnumerable<CMemberSimpleViewModel> members = null;
            members = from m in db.Members
                      select new CMemberSimpleViewModel
                      {
                          Name = m.Name,
                          BirthDate = m.BirthDate,
                          ResidesInCareHome = m.ResidesInCareHome
                      };
            return View(members);

        }
        public IActionResult Create() { 
            return View();
        }
        [HttpPost]
        public IActionResult Create(CMemberSimpleViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            using var db = new NursingHomeContext();

            var member = new Member
            {
                Name = vm.Name,
                BirthDate = vm.BirthDate,
                ResidesInCareHome = vm.ResidesInCareHome
            };

            db.Members.Add(member);
            db.SaveChanges();

            return RedirectToAction("List");
        }

        public IActionResult Edit(int? id) {
            if (id == null)
                return RedirectToAction("List");
            NursingHomeContext db = new NursingHomeContext();
            var m = db.Members.FirstOrDefault(x=>x.MemberId == id);
            if (m == null) return RedirectToAction("List");

            return View(m);
        
        }

        [HttpPost]
        public IActionResult Edit(Member m) {
            NursingHomeContext db = new NursingHomeContext();
            var member = db.Members.FirstOrDefault(x=>x.MemberId == m.MemberId);
            if (member == null) return RedirectToAction("List");

            member.Name = m.Name;
            member.BirthDate = m.BirthDate;
            member.ResidesInCareHome = m.ResidesInCareHome;
>>>>>>> Stashed changes
            db.SaveChanges();
            return RedirectToAction("List");
        }

<<<<<<< Updated upstream

    }
}
=======
        public IActionResult Delete(int? id) { 
            if(id == null) return RedirectToAction("List");
            NursingHomeContext db = new NursingHomeContext();
            var m = db.Members.FirstOrDefault(x => x.MemberId == id);
            if (m != null)
            { 
                db.Members.Remove(m);
                db.SaveChanges();
            }
            return RedirectToAction("List");
            
        }


    }
}
>>>>>>> Stashed changes
