using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SeyahatProject.DBContext;
using SeyahatProject.Models;

namespace SeyahatProject.ViewComponents
{
    public class HomeRightPartialViewComponent : ViewComponent
    {
        private readonly Context _Context;

        public HomeRightPartialViewComponent(Context context)
        {
            _Context = context;
        }
        public IViewComponentResult Invoke(int Id)
        {
            var deger = _Context.Blogs.OrderByDescending(x=>x.ID).Take(3).ToList();
            return View(deger[2]);
        }
    }
}
