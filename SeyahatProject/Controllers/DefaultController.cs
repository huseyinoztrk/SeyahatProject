using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Newtonsoft.Json;
using SeyahatProject.DBContext;

namespace SeyahatProject.Controllers
{
    public class DefaultController : Controller
    {
        private readonly Context _Context;
        private readonly IHtmlLocalizer<DefaultController> _localizer;
        public DefaultController(Context context, IHtmlLocalizer<DefaultController> localizer)
        {
            _Context = context;
            _localizer = localizer;
        }

        [HttpPost]
        public IActionResult MenagerLanguage(string language, string urlReturn)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(language)),
            new CookieOptions { Expires = DateTimeOffset.Now.AddDays(15)});
            //return RedirectToAction(nameof(Index));
            return LocalRedirect(urlReturn);
        }

        public IActionResult Index()
        {
            var testDescController = _localizer["anasayfa"];
            ViewData["anasayfa"] = testDescController;
            var degerler = _Context.Blogs.Take(8).ToList();
            return View(degerler);
        }
        public IActionResult About()
        {
            return View();
        }
    }
}
