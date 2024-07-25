using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIPro.Models;

namespace WebAPIPro.DataAccess.IRepository
{
    public interface IEmpRepository
    {
        Task<List<Employee>> AllEmployees();
        Task<Employee> GetEmployeeByEmpId(int EmpId);
        Task<List<Employee>> GetEmployeeByDeptNo(int DeptNo);
        Task<Employee> GetEmployeeByEmailAndPassword(string Email, string Password);
        Task<Employee> GetEmployeeByOnlyEmail(string Email);
        Task<int> InsertEmployee(Employee Emp);
        Task<int> UpdateEmployee(Employee Emp);
        Task<int> DeleteEmployee(int EmpId);
        Task<int> DeleteAllEmployee();
    }
}
