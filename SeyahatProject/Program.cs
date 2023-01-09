using SeyahatProject.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

var builder = WebApplication.CreateBuilder(args);

//Localization settings
builder.Services.AddLocalization(option => { option.ResourcesPath = "Resources"; });
builder.Services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();

//Localization Cookie setting
builder.Services.Configure<RequestLocalizationOptions>(
    option =>
    {
        var languageSupport = new List<CultureInfo>
        {
            new CultureInfo("tr"),
            new CultureInfo("en")
        };

        option.DefaultRequestCulture = new RequestCulture("tr");
        option.SupportedCultures = languageSupport;
        option.SupportedUICultures = languageSupport;
    }
    );

builder.Services.AddControllersWithViews();

//Authentication settings
builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        option.LoginPath = "/Access/Login";
        option.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    });

builder.Services.AddDBServices();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseRequestLocalization();

//var languageSupported = new[] { "tr", "en" };
//var optionsLocalization = new RequestLocalizationOptions().SetDefaultCulture(languageSupported[0])
//    .AddSupportedCultures(languageSupported)
//    .AddSupportedUICultures(languageSupported);

//app.UseRequestLocalization(languageSupported);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();
