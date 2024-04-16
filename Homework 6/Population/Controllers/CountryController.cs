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
			string[] citiesArray = Array.Empty<string>();

			if (cities != null)
			{
				citiesArray = cities.Split('/');
			}

			var storedCity = new CityViewModel
			{
				City = "",  //All cities
				Country = "China",
				Population = 1412000000,
			};

			Cities.Add(storedCity);

			storedCity = new CityViewModel
			{
				City = "Rome",
				Country = "Italy",
				Population = 2873000,
			};
			Cities.Add(storedCity);

			storedCity = new CityViewModel
			{
				City = "Venice",
				Country = "Italy",
				Population = 261900,
			};
			Cities.Add(storedCity);


			var citiesForView = new List<CityViewModel>();

			if (country != null)
			{
				if (citiesArray.Length != 0)
				{
					foreach (string city in citiesArray)
					{
						var ct = Cities.First(item => item.Country == country && item.City == city);
						if (ct != null)
						{
							citiesForView.Add(ct);
						}
					}
				}
				else
				{
					var ct = Cities.First(item => item.Country == country);
					if (ct != null)
					{
						citiesForView.Add(ct);
					}
				}
			}

			try
			{
				return View(citiesForView);
			}
			catch
			{
				return NotFound("No such record found!");
			}
		}
	}
}
