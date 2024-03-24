using HelpDesk_DomainModel.Models.Identity;

namespace HelpDesk_BLL.Contracts.Identity
{
	public interface IEmployeeService
	{
		public List<Employee> GetEmployees();

		public Task<Employee?> GetEmployeeById(long employeeId);
		public Task<Employee> CreateEmployee(Employee employee);

		public Task WriteEmployee(Employee employeeToWrite);

		public Task DeleteEmployee(long employeeId);
	}
}
