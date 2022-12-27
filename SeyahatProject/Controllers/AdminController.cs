using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SeyahatProject.DBContext;
using SeyahatProject.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.CodeAnalysis.Operations;

namespace SeyahatProject.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly Context _Context;

        public AdminController(Context context)
        {
            _Context = context;
        }
        [Authorize]
        public IActionResult Index()
        {
            var degerler = _Context.Blogs.ToList();
            return View(degerler);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Access");
        }

        [HttpGet]
        public IActionResult YeniBlog()
        {
            return View();
        }
        [HttpPost]
        public IActionResult YeniBlog(BlogVM p)
        {

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            Blog b = new()
            {
                Baslik = p.Baslik,
                Tarih = DateOnly.Parse(p.Tarih),
                Aciklama = p.Aciklama,
                BlogImage = p.BlogImage,

            };
            _Context.Blogs.Add(b);
            _Context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult BlogSil(int id)
        {
            var b = _Context.Blogs.Find(id);
            _Context.Blogs.Remove(b);
            _Context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult BlogGetir(int id)
        {
            var bl = _Context.Blogs.Find(id);
            return View("BlogGetir", bl);
        }
        public IActionResult BlogGuncelle(Blog b)
        {
            var blg = _Context.Blogs.Find(b.ID);
            blg.Aciklama = b.Aciklama;
            blg.Baslik = b.Baslik;
            blg.BlogImage = b.BlogImage;
            blg.Tarih = b.Tarih;
            _Context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult YorumListesi()
        {
            var yorumlar = _Context.Yorumlars.ToList();
            return View(yorumlar);
        }
        public IActionResult YorumSil(int id)
        {
            var b = _Context.Yorumlars.Find(id);
            _Context.Yorumlars.Remove(b);
            _Context.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
        public IActionResult YorumGetir(int id)
        {
            var yr = _Context.Yorumlars.Find(id);
            return View("YorumGetir", yr);
        }
        public IActionResult YorumGuncelle(Yorumlar y)
        {
            var yrm = _Context.Yorumlars.Find(y.ID);
            yrm.KullaniciAdi = y.KullaniciAdi;
            yrm.Mail = y.Mail;
            yrm.Yorum = y.Yorum;
            _Context.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
        public IActionResult iletisim(iletisim ilet)
        {
            var iletisim = _Context.iletisims.ToList();
            return View(iletisim);
        }
        public IActionResult iletisimSil(int id)
        {
            var iletim = _Context.iletisims.Find(id);
            _Context.iletisims.Remove(iletim);
            _Context.SaveChanges();
            return RedirectToAction("iletisim");
        }
        public IActionResult iletisimGetir(int id)
        {
            var iletisimss = _Context.iletisims.Find(id);
            return View("iletisimGetir", iletisimss);
        }
        public IActionResult iletisimGuncelle(iletisim iltg)
        {
            var ilg = _Context.iletisims.Find(iltg.ID);
            ilg.AdSoyad = iltg.AdSoyad;
            ilg.Mail = iltg.Mail;
            ilg.Konu = iltg.Konu;
            ilg.Mesaj = iltg.Mesaj;
            _Context.SaveChanges();
            return RedirectToAction("iletisim");
        }
        public IActionResult HakkimizdaEkrani(Hakkimizda Hakkimizdass)
        {
            var hakkimiz = _Context.Hakkimizdas.ToList();
            return View(hakkimiz);
        }
        public IActionResult Hakkimizda(int id)
        {
            var hkmz = _Context.Hakkimizdas.Find(id);
            return View("Hakkimizda", hkmz);
        }
        public IActionResult HakkimizdaGuncelle(Hakkimizda h)
        {
            var hak = _Context.Hakkimizdas.Find(h.ID);
            hak.FotoUrl = h.FotoUrl;
            hak.Aciklama = h.Aciklama;
            _Context.SaveChanges();
            return RedirectToAction("HakkimizdaEkrani");
        }
        public IActionResult Adminler(Admin adminn)
        {
            var adminler = _Context.Admins.ToList();
            return View(adminler);
        }
        public IActionResult AdminGuncelle(Admin adm)
        {
            var admiin = _Context.Admins.Find(adm.ID);
            admiin.Kullanici = adm.Kullanici;
            admiin.Sifre = adm.Sifre;
            _Context.SaveChanges();
            return RedirectToAction("Adminler");
        }
        public IActionResult AdminSil(int id)
        {
            var adminle = _Context.Admins.Find(id);
            _Context.Admins.Remove(adminle);
            _Context.SaveChanges();
            return RedirectToAction("Adminler");
        }
        [HttpGet]
        public IActionResult YeniAdmin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult YeniAdmin(AdminVM ad)
        {

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Adminler");
            }
            Admin nadmin = new()
            {
                Kullanici = ad.Kullanici,
                Sifre = ad.Sifre,

            };
            _Context.Admins.Add(nadmin);
            _Context.SaveChanges();
            return RedirectToAction("Adminler");
        }
        public IActionResult AdminGetir(int id)
        {
            var admbl = _Context.Admins.Find(id);
            return View("AdminGetir", admbl);
        }
    }
}
