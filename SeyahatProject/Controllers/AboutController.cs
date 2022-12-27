using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SeyahatProject.DBContext;

namespace SeyahatProject.Controllers
{
	public class AboutController : Controller
	{
		private readonly Context _Context;

		public AboutController(Context context)
		{
			_Context = context;
		}

		public IActionResult Index()
		{
			var degerler = _Context.Hakkimizdas.ToList();
			return View(degerler);
		}
	}
}
