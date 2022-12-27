using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using SeyahatProject.Models;
using SeyahatProject.DBContext;

namespace SeyahatProject.Controllers
{
    public class AccessController : Controller
    {
        private readonly Context _Context;

        public AccessController(Context context)
        {
            _Context = context;
        }

        public IActionResult Login()
        {
            ClaimsPrincipal claimUser = HttpContext.User;

            if (claimUser.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Access");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(VMLogin modelLogin)
        {
            if (_Context.Admins.Where(x => x.Kullanici == modelLogin.KullaniciAdiEmail && x.Sifre == modelLogin.Password).SingleOrDefault() != null)
            {
                List<Claim> claims = new List<Claim>() {
                new Claim(ClaimTypes.GivenName,modelLogin.KullaniciAdiEmail),
                new Claim("OtherProperties","Example Role")
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    IsPersistent = modelLogin.KeepLoogedIn
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), properties);

                return RedirectToAction("Index", "Admin");
            }

            ViewData["ValidateMessage"] = "Kullanıcı Bulunamadı..!!";
            return View();
        }
    }
}
