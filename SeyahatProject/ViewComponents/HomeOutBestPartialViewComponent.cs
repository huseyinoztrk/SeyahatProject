using Microsoft.AspNetCore.Mvc;
using SeyahatProject.DBContext;

namespace SeyahatProject.ViewComponents
{
    public class HomeOutBestPartialViewComponent : ViewComponent
    {
        private readonly Context _Context;

        public HomeOutBestPartialViewComponent(Context context)
        {
            _Context = context;
        }
        public IViewComponentResult Invoke()
        {
            var deger = _Context.Blogs.Take(3).ToList();
            return View(deger);
        }
    }
}
