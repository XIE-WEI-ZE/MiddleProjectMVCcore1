using Microsoft.AspNetCore.Mvc;
using prjCareHomeSystem.ViewModels;
using PrjMiddleProject.Models;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace PrjMiddleProject.Controllers
{
    public class LoginController : Controller
    {
        private readonly NursingHomeContext _context;
        private readonly ILogger<HomeController> _logger;



        public LoginController(NursingHomeContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            if (HttpContext.Session.Keys.Contains(CDictionary.SK_LOGIN_USER))
            {
                string json = HttpContext.Session.GetString(CDictionary.SK_LOGIN_USER);
                var member = JsonSerializer.Deserialize<Member>(json);
                ViewBag.Message = $"{member.Username}";
            }
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(CRegisterViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            if (string.IsNullOrEmpty(vm.Account)) {
                ModelState.AddModelError("Account", "帳號不可為空");
                return View();
            }


            if (_context.Members.Any(m => m.Account == vm.Account))
            {
                ViewBag.Message = "帳號已存在";
                return View(vm);
            }

            // 產生 salt 並加密密碼
            string salt = Guid.NewGuid().ToString().Substring(0, 8);
            string saltedPwd = vm.Password + salt;
            string hashPwd = Convert.ToBase64String(
                SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(saltedPwd))
            );

            // 建立新會員
            Member m = new Member
            {
                Name = vm.Name,
                Account = vm.Account,
                Email = vm.Email,
                Gender = vm.Gender,
                City = vm.City,
                District = vm.District,
                RoadAddress = vm.RoadAddress,
                Password = hashPwd,
                PasswordSalt = salt,
                BirthDate = vm.BirthDate,
                Role = vm.Role,
                CreatedDate = DateTime.Now
            };

            _context.Members.Add(m);
            _context.SaveChanges();

            TempData["message"] = "註冊成功，請您登入";
            return RedirectToAction("Login", "Login");
        }

        public IActionResult Login()
        {
            // 若已登入，不再進入登入頁，直接導回首頁
            if (HttpContext.Session.GetString(CDictionary.SK_LOGIN_USER) != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(CLoginViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var member = _context.Members.FirstOrDefault(m => m.Account == vm.Account);
            if (member == null)
            {
                ViewBag.Message = "帳號不存在";
                return View(vm);
            }

            string salted = vm.Password + member.PasswordSalt;
            string hashPwd = Convert.ToBase64String(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(salted)));
            if (hashPwd != member.Password)
            {
                ViewBag.Message = "密碼錯誤";
                return View(vm);
            }

            // 儲存登入者資料到 Session
            string json = JsonSerializer.Serialize(member);
            HttpContext.Session.SetString(CDictionary.SK_LOGIN_USER, json);


            return RedirectToAction("Index", "Home");
        }


    }
}
