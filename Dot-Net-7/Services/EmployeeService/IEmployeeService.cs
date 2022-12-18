using Dot_Net_7.Models;

namespace Dot_Net_7.Services.EmployeeService
{
    public interface IEmployeeService
    {
        Task<List<Employee>?> GetAllEmployes();
        Task<Employee?> GetSingleEmployee(int id);
        Task<Employee?> AddEmployes(Employee request);
        Task<Employee?> UpdateEmployes(Employee request);
        Task<Employee?> DeleteEmployes(int id);



    }
}
