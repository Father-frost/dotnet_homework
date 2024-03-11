using HelpDesk_BLL.Contracts.Identity;
using HelpDesk_TestMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace HelpDesk_TestMVC.Controllers
{
    public class EmployeeController : Controller
    {

        static List<EmployeeViewModel> Employees = new List<EmployeeViewModel>();

		private IEmployeeService _employeeService;
		public EmployeeController(IEmployeeService employeeService)
		{
			_employeeService = employeeService;
		}

		// GET: EmployeeController
		public ActionResult Index()
        {
            //return View(Employees);
            return View(_employeeService.GetEmployees());
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound("Empty id supplied!");
            }

            try
            {
                var employee = Employees[id.Value];
                return View(employee);
            }
            catch
            {
				return NotFound("No such record found!");
			}
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        //Adding an Employee to List
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeViewModel employee)
        {
            try
            {
                employee.Id = Employees.Count;
                Employees.Add(employee);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int? id)
        {
			if (!id.HasValue)
			{
				return NotFound("Empty id supplied!");
			}

            try
            {
                var employee = Employees[id.Value];
                return View(employee);
            }
            catch
            {
				return NotFound("No such record found!");
			}
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EmployeeViewModel employee)
        {
            try
            {
                Employees[id] = employee;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

		// GET: EmployeeController/Delete/5
		[HttpGet]
		public ActionResult Delete(int? id)
		{
			if (!id.HasValue)
			{
				return NotFound("Empty id supplied!");
			}
            try
            {
                var employee = Employees[id.Value];

                return View(employee);
            }
            catch
            {
				return NotFound("No such record found!");
			}
		}

		// POST: EmployeeController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int? id, EmployeeViewModel employee)
		{
            try
            {
                employee = Employees[id.Value];
                Employees.Remove(employee);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
				return NotFound("No such record found!");
			}
		}

	}
}
