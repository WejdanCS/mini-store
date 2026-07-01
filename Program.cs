using Microsoft.EntityFrameworkCore;
using mini_store.Data;
using mini_store;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddControllersWithViews();
// DB Configuration
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Identity 
builder.Services.AddDefaultIdentity<AppUser>(options =>
{
    // configure password and signIn 
    // options.SignIn.RequireConfirmedAccount = false;
    // options.Password.RequireDigit = false;
    // options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
    // options.Password.RequireUppercase = false;
    // options.Password.RequireLowercase = false;

})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();
// تخصيص مسارات تسجيل الدخول لتشير إلى الـ Controller الخاص بك بدلاً من Identity الافتراضي
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    // options.LogoutPath = "/Account/Logout";
    // options.AccessDeniedPath = "/Account/AccessDenied"; // اختياري في حال عدم وجود صلاحيات
});
// ----------- Localization -----------
builder.Services.AddControllersWithViews()
    .AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization(options =>
    {
        options.DataAnnotationLocalizerProvider = (type, factory) =>
            factory.Create(typeof(SharedResource));
    });
var supportedCultures = new[] { "ar", "en", "fr" };
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.SetDefaultCulture(supportedCultures[0]);
    options.AddSupportedCultures(supportedCultures);
    options.AddSupportedUICultures(supportedCultures);
    // إزالة مزود لغة المتصفح //
    // Optional
    // var browserLanguageProvider = options.RequestCultureProviders
    // .OfType<Microsoft.AspNetCore.Localization.AcceptLanguageHeaderRequestCultureProvider>()
    // .FirstOrDefault();
    // if (browserLanguageProvider != null)
    // {
    //     options.RequestCultureProviders.Remove(browserLanguageProvider);
    // }
}
);
var app = builder.Build();
// Use Localization
app.UseRequestLocalization();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();