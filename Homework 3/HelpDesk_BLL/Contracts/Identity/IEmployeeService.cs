using HelpDesk_DomainModel.Models.Identity;

namespace HelpDesk_BLL.Contracts.Identity
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployees();

        Task <Employee> CreateEmployee(Employee employee);
		Task <Employee> UpdateEmployeeContactData(Employee employee);
		Task <Employee> DeleteEmployee(long employeeId);
        Task<Employee> SetEmployeePost(long employeeId, PostEnum newPost);
    }
}
