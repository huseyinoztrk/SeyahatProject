using Microsoft.AspNetCore.Mvc;
using SeyahatProject.DBContext;
using SeyahatProject.Models;

namespace SeyahatProject.Controllers
{
    public class ContactController : Controller
    {
        private readonly Context _Context;

        public ContactController(Context context)
        {
            _Context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult iletisimGonder(iletisim ilt)
        {
            iletisim _ilt = new()
            {
                AdSoyad = ilt.AdSoyad,
                Mail = ilt.Mail,
                Konu = ilt.Konu,
                Mesaj = ilt.Mesaj,
            };
            _Context.iletisims.Add(_ilt);
            _Context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
