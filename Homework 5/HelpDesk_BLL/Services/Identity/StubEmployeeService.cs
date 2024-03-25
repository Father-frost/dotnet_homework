using HelpDesk_BLL.Contracts.Identity;
using HelpDesk_DAL;
using HelpDesk_DomainModel.Models.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace HelpDesk_BLL.Services.Identity
{
	public class StubEmployeeService : IEmployeeService
	{
		private readonly IUnitOfWork _unitOfWork;

		public StubEmployeeService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public List<Employee> GetEmployees()
		{

			var emptyList = new List<Employee>();

			return emptyList;
		}

		public Employee GetEmployeeById(long? employeeId)
		{
			throw new NotImplementedException();
		}

		public async Task<Employee> CreateEmployee(Employee employee)
		{
			var repo = _unitOfWork.GetRepository<Employee>();

			var newDbEmployee = new Employee
			{
				FirstName = employee.FirstName,
				LastName = employee.LastName,
				Email = employee.Email,
				Post = employee.Post,
			};

			Employee trackedEmployee = repo.Create(newDbEmployee);

			await _unitOfWork.SaveChangesAsync();

			return trackedEmployee;
		}

		public async Task WriteEmployee(Employee employeeToWrite)
		{
			throw new NotImplementedException();
		}

		public async Task DeleteEmployee(long employeeId)
		{
			throw new NotImplementedException();
		}


	}
}
