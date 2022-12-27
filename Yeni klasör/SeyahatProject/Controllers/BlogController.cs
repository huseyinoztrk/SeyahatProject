using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SeyahatProject.DBContext;
using SeyahatProject.Models;
using SeyahatProject.Models.VievModels;

namespace SeyahatProject.Controllers
{
    public class BlogController : Controller
    {
        private readonly Context _Context;

        public BlogController(Context context)
        {
            _Context = context;
        }

        BlogYorum by = new BlogYorum();
        public IActionResult Index()
        {
            by.Deger1 = _Context.Blogs.ToList();
            by.Deger3 = _Context.Blogs.OrderByDescending(x => x.ID).Take(5).ToList();
            return View(by);
        }

        public IActionResult BlogDetay(int id)
        {
            by.Deger4 = _Context.Blogs.Where(x => x.ID == id).Single();
            by.Deger2 = _Context.Yorumlars.Where(x => x.Blogid == id).ToList();
            ViewBag.Blogid = id;
            return View(by);
        }

        [HttpGet]
        public PartialViewResult YorumYap()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult YorumYap(YorumlarVM y)
        {
            Yorumlar _y = new()
            {
                KullaniciAdi = y.KullaniciAdi,
                Mail = y.Mail,
                Yorum = y.Yorum,
                Blogid = y.Blogid,
            };
            _Context.Yorumlars.Add(_y);
            _Context.SaveChanges();
            return RedirectToAction("BlogDetay", new { id = y.Blogid });
        }
    }
}
