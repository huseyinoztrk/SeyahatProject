using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SeyahatProject.DBContext;

namespace SeyahatProject.Controllers
{
    public class DefaultController : Controller
    {
        private readonly Context _Context;

        public DefaultController(Context context)
        {
            _Context = context;
        }

        public IActionResult Index()
        {
            var degerler = _Context.Blogs.Take(8).ToList();
            return View(degerler);
        }
        public IActionResult About()
        {
            return View();
        }
    }
}
