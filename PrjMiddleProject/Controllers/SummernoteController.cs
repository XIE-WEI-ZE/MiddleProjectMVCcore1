using Microsoft.AspNetCore.Mvc;

namespace PrjMiddleProject.Controllers
{
    [Route("api/summernote")]
    public class SummernoteController : Controller
    {
        private readonly IWebHostEnvironment _env;
        public SummernoteController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest();

            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string folderPath = Path.Combine(_env.WebRootPath, "images", "summernote", "upload");
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            string filePath = Path.Combine(folderPath, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            string url = $"/images/summernote/upload/{fileName}";
            return Json(new { url });
        }
    }

}
