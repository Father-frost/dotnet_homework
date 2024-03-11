using HelpDesk_BLL.Contracts.Identity;
using HelpDesk_DAL;
using HelpDesk_DomainModel.Models.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HelpDesk_BLL.Services.Identity
{
	public class EmployeeService : IEmployeeService
	{
		private readonly IUnitOfWork _unitOfWork;

		public EmployeeService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public List<Employee> GetEmployees()
		{
			var repo = _unitOfWork.GetRepository<Employee>();

			var query = repo.AsReadOnlyQueryable();

			query = from employee in query
					select employee;

			var projectedQuery = from employee in query
								 select new Employee
								 {
									 Id = employee.Id,
									 Email = employee.Email,
									 FirstName = employee.FirstName,
									 LastName = employee.LastName,
									 Post = employee.Post,
								 };

			return projectedQuery.ToList();
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

		public Task<Employee> DeleteEmployee(long employeeId)
		{
			throw new NotImplementedException();
		}


		public Task<Employee> SetEmployeePost(long employeeId, PostEnum newPost)
		{
			throw new NotImplementedException();
		}

		public Task<Employee> UpdateEmployeeContactData(Employee employee)
		{
			throw new NotImplementedException();
		}
	}
}
