using BusinessLayer.ValidationRules;
using Core_Portfolio.Data;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// 1. Servis kayıtları
builder.Services.AddControllersWithViews();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<PortfolioValidator>();

builder.Services.AddDbContext<Context>();

builder.Services.AddIdentity<WriterUser, IdentityRole<int>>()
    .AddEntityFrameworkStores<Context>()
    .AddDefaultTokenProviders();

// ✅ MVC global authorize filter
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();

    config.Filters.Add(new AuthorizeFilter(policy));
});

// ✅ Identity cookie ayarları
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true; //Çerezin sadece sunucu tarafından erişilebilir olmasını sağlar (JS erişemez).
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60); //oturum süresini belirler
    options.SlidingExpiration = true; //Aktif kullanıcı oturum süresi dolmadan işlem yaparsa süre uzatılır.
    options.LoginPath = "/User/Login/Index/"; //Yetkisiz kullanıcıların yönlendirileceği giriş sayfası.
});

// 2. Uygulamayı oluştur
var app = builder.Build();

// Roller veritabanında yoksa ekle
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();
    await SeedData.SeedRoles(roleManager);
}

// 3. Middleware pipeline
app.UseRequestLocalization();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseStatusCodePagesWithReExecute("/Error/{0}");

// 🔹 Eğer URL'de bir Area varsa, varsayılan olarak 'Dashboard' controller'ı ve 'Index' action'ı çalıştırılır.
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

// 🔹 Eğer URL'de area belirtilmemişse, varsayılan area 'User' olarak kabul edilir.
app.MapControllerRoute(
    name: "default_with_area",
    pattern: "{area=User}/{controller=Default}/{action=Index}/{id?}");

app.Run();
