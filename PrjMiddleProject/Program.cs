using Microsoft.EntityFrameworkCore;
using PrjMiddleProject.Models;

var builder = WebApplication.CreateBuilder(args);

// 加入 MVC
builder.Services.AddControllersWithViews();

// 加入資料庫連線
builder.Services.AddDbContext<NursingHomeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("dbConn")));

//加入 Session 與 HttpContextAccessor
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); 
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    //Login Login
    //Home Index
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
