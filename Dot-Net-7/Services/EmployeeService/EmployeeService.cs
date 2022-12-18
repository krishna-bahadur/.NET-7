using Dot_Net_7.Data;
using Dot_Net_7.Models;
using Microsoft.EntityFrameworkCore;

namespace Dot_Net_7.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly DataContext _dataContext;
        public EmployeeService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Employee?> AddEmployes(Employee request)
        {
            _dataContext.Add(request);
            var affectedRow = await _dataContext.SaveChangesAsync();
            if(affectedRow > 0)
                return request;
            return null;
        }

        public async Task<Employee?> DeleteEmployes(int id)
        {
            var emp = _dataContext.Employees.Find(id);
            if (emp is null)
                return null;
            _dataContext.Remove(emp);
            var affectedRow =await _dataContext.SaveChangesAsync();
            if(affectedRow > 0)
                return emp;
            return null;
        }

        public async Task<List<Employee>?> GetAllEmployes()
        {
            var employees = await _dataContext.Employees.ToListAsync();
            if(employees.Count() > 0)
                return employees;
            return null;
        }

        public async Task<Employee?> GetSingleEmployee(int id)
        {
            var emp = await _dataContext.Employees.FindAsync(id);
            if (emp is null)
                return null;
            return emp;
        }

        public async  Task<Employee?> UpdateEmployes(Employee request)
        {
            var emp =await _dataContext.Employees.FindAsync(request.Id);
            if (emp is null)
                return null;
            emp.FirstName = request.FirstName;
            emp.LastName = request.LastName;
            emp.Address = request.Address;
            _dataContext.Update(emp);
            var affectedrow =await _dataContext.SaveChangesAsync();
            if (affectedrow > 0)
                return emp;
            return null;
        }
    }
}
