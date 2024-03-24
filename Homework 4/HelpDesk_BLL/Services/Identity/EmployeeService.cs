using HelpDesk_BLL.Contracts.Identity;
using HelpDesk_DAL;
using HelpDesk_DomainModel.Models.Identity;

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
									 Skills = employee.Skills,
								 };

			return projectedQuery.ToList();
		}

		public Employee? GetEmployeeById(long? employeeId)
		{
			var repo = _unitOfWork.GetRepository<Employee>();
			
			var employee = repo.AsReadOnlyQueryable()
				.FirstOrDefault(em => em.Id == employeeId);
			
			return employee;
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
				Skills = employee.Skills,
			};

			Employee trackedEmployee = repo.Create(newDbEmployee);

			await _unitOfWork.SaveChangesAsync();

			return trackedEmployee;
		}

		public async Task WriteEmployee(Employee employeeToWrite)
		{
			var repo = _unitOfWork.GetRepository<Employee>();

			repo.InsertOrUpdate(
			employee => employee.Id == employeeToWrite.Id,
			employeeToWrite
			);

			await _unitOfWork.SaveChangesAsync();
		}


		public async Task DeleteEmployee(long employeeId)
		{
			var repo = _unitOfWork.GetRepository<Employee>();
			var trackedEmployee = repo
				.AsQueryable()
				.First(em => em.Id == employeeId);

			repo.Delete(trackedEmployee);
			await _unitOfWork.SaveChangesAsync();
		}

	}
}
