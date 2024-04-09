using Microsoft.AspNetCore.Mvc;
using Population.Models;
using System.Diagnostics;

namespace Population.Controllers
{
	public class CountryController : Controller
	{
		private readonly ILogger<CountryController> _logger;

		public CountryController(ILogger<CountryController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
