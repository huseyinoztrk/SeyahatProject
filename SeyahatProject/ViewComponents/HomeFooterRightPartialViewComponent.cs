using Microsoft.AspNetCore.Mvc;
using SeyahatProject.DBContext;

namespace SeyahatProject.ViewComponents
{
    public class HomeFooterRightPartialViewComponent : ViewComponent
    {
        private readonly Context _Context;

        public HomeFooterRightPartialViewComponent(Context context)
        {
            _Context = context;
        }
        public IViewComponentResult Invoke()
        {
            var deger = _Context.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            return View(deger);
        }

    }
}
