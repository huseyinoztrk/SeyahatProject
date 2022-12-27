using Microsoft.AspNetCore.Mvc;
using SeyahatProject.DBContext;

namespace SeyahatProject.Controllers
{
    public class PhotoController : Controller
    {
        private readonly Context _Context;

        public PhotoController(Context context)
        {
            _Context = context;
        }
        public IActionResult Index()
        {
            var degerler = _Context.Blogs.ToList();
            return View(degerler);
        }
    }
}
