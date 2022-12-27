using Microsoft.AspNetCore.Mvc;
using SeyahatProject.DBContext;

namespace SeyahatProject.ViewComponents
{
    public class HomeSidePartialViewComponent : ViewComponent
    {
        private readonly Context _Context;

        public HomeSidePartialViewComponent(Context context)
        {
            _Context = context;
        }

        public IViewComponentResult Invoke()
        {
            var deger = _Context.Blogs.OrderByDescending(x => x.ID).Take(10).ToList();
            return View(deger);
        }
    }
}
