using HelpDesk_DomainModel.Models.Identity;
using HelpDesk_MVC.Models;
using HelpDesk_MVC.RequestFilters;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace HelpDesk_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

			if (User.Identity.IsAuthenticated)
            {
                var actualRole = User.Claims.FirstOrDefault(cl => cl.Type == "ActualRole").Value.ToString() ?? null;

                if (actualRole == UserRoleEnum.Administrator.ToString())
                {
                    return RedirectToAction("AdminPanel");

                }
                if (actualRole == UserRoleEnum.Manager.ToString())
                {
                    return RedirectToAction("ManagerPanel");

                }
                if (actualRole == UserRoleEnum.Employee.ToString())
                {
                    return RedirectToAction("EmployeePanel");

                }
				if (actualRole == UserRoleEnum.Customer.ToString())
				{
					return RedirectToAction("CustomerPage");

				}
				return View();
			}

            return View();
        }

        [RoleBasedAuthorizationFilter(Role = UserRoleEnum.Administrator)]
        public IActionResult AdminPanel()
        {
            return View();
        }

        [RoleBasedAuthorizationFilter(Role = UserRoleEnum.Manager)]
        public IActionResult ManagerPanel()
        {
            return View();
        }

        [RoleBasedAuthorizationFilter(Role = UserRoleEnum.Customer)]
        public IActionResult CustomerPage()
        {
            return View();
        }

        [RoleBasedAuthorizationFilter(Role = UserRoleEnum.Employee)]
        public IActionResult EmployeePanel()
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
