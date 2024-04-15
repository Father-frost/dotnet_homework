using Microsoft.AspNetCore.Mvc;
using Population.Models;
using System.Diagnostics;

namespace Population.Controllers
{
	public class CountryController : Controller
	{
		static List<CityViewModel> Cities = new List<CityViewModel>();

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

		public IActionResult GetPopulation(string country, string cities)
		{
			string[] citiesArray  = cities.Split('/');
								
			var storedCity = new CityViewModel
			{
				City = "",	//All cities
				Country = CountryEnum.China,
				Population = 1412000000,
			};

			Cities.Add(storedCity);
			
			storedCity = new CityViewModel
			{
				City = "Rome",
				Country = CountryEnum.Italy,
				Population = 2873000,
			};
			Cities.Add(storedCity);

			storedCity = new CityViewModel
			{
				City = "Venice",
				Country = CountryEnum.Italy,
				Population = 261900,
			};
			Cities.Add(storedCity);

			return View();
		}
	}
}
