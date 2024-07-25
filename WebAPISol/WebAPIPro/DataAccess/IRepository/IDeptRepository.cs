using System.Collections.Generic;
using WebAPIPro.Models;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPIPro.DataAccess.IRepository
{
    public interface IDeptRepository
    {
        Task<List<Department>> AllDepartments();
        Task<Department> GetDepartmentByDeptNo(int DeptNo);
        Task<List<Department>> GetDepartmentByLocation(string Location);
        Task<int> InsertDepartment(Department Dept);
        Task<int> UpdateDepartment(Department Dept);
        Task<int> DeleteDepartment(int DeptNo);
    }
}
