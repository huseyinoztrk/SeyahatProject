using Microsoft.AspNetCore.Mvc;
using SeyahatProject.DBContext;

namespace SeyahatProject.ViewComponents
{
    public class HomePartialViewComponent : ViewComponent
    {
        private readonly Context _Context;

        public HomePartialViewComponent(Context context)
        {
            _Context = context;
        }
        public IViewComponentResult Invoke()
        {
            var result = _Context.Blogs.OrderByDescending(x => x.ID).Take(2).ToList();
            return View(result);
        }
    }
}
