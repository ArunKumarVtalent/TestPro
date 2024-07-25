using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIPro.DataAccess.IRepository;
using WebAPIPro.Models;
using WebAPIPro.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection.Emit;

namespace WebAPIPro.DataAccess.Repository
{
    public class DeptRepository : IDeptRepository
    {
        public DBContextPro DeptDb;

        public DeptRepository(DBContextPro _DeptDb)
        {
            DeptDb = _DeptDb;
        }

        // DRL/DQL Command Sql Operation:
        public async Task<List<Department>> AllDepartments()
        {
            // Logic to use Entity Framework "Context Class" to Read All the Data from Department Database Table
            return await DeptDb.Departments.ToListAsync();
        }

        public async Task<Department> GetDepartmentByDeptNo(int DeptNo)
        {
            return await DeptDb.Departments.FindAsync(DeptNo);
        }

        public async Task<List<Department>> GetDepartmentByLocation(string Location)
        {
            return await DeptDb.Departments.Where(x => x.Location == Location).ToListAsync();
        }


        // DML Commands Sql Operations :
        public async Task<int> InsertDepartment(Department Dept)
        {
            await DeptDb.Departments.AddAsync(Dept); //It is not Enough
            return await DeptDb.SaveChangesAsync(); // It will commite the db and returns effected count value
        }

        public async Task<int> UpdateDepartment(Department Dept)
        {
            DeptDb.Departments.Update(Dept);
            return await DeptDb.SaveChangesAsync();
        }

        public async Task<int> DeleteDepartment(int DeptNo)
        {
            var dept = DeptDb.Departments.Find(DeptNo);
            DeptDb.Departments.Remove(dept);
            return await DeptDb.SaveChangesAsync();
        }

    }
}
