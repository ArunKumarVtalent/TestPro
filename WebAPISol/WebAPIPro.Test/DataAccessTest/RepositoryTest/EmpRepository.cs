using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPIPro.DataAccess;
using WebAPIPro.DataAccess.IRepository;
using WebAPIPro.Models;

namespace WebAPIPro.Test.DataAccessTest.RepositoryTest
{
    internal class EmpRepository : IEmpRepository
    {
        public List<Employee> _db = new List<Employee>();
        public Task<List<Employee>> AllEmployees()
        {
            return Task.FromResult(_db);
        }

        public Task<int> DeleteAllEmployee()
        {
            var Tcount = TotalRecords();
            _db.Clear();
            return Task.FromResult(Tcount);
        }

        public Task<int> DeleteEmployee(int EmpId)
        {
            Employee emp = null;
            foreach (Employee e in _db)
            {
                if (e.EmpId == EmpId) { emp = e; break; }
            }
            _db.Remove(emp);
            return Task.FromResult(SaveChanges());
        }

        public Task<List<Employee>> GetEmployeeByDeptNo(int DeptNo)
        {
            List<Employee> lemp = new List<Employee>();
            foreach (Employee e in _db)
            {
                if (e.DeptNo == DeptNo)
                {
                    lemp.Add(e);
                }
            }
            return Task.FromResult(lemp);
        }

        public Task<Employee> GetEmployeeByEmailAndPassword(string Email, string Password)
        {
            Employee lemp = null;
            foreach (Employee e in _db)
            {
                if (e.Email == Email && e.Password == Password)
                {
                    lemp = e;break;
                }
            }
            return Task.FromResult(lemp);

            //List<Employee> lemp = new List<Employee>();
            //foreach (Employee e in _db)
            //{
            //    if (e.Email == Email && e.Password == Password)
            //    {
            //        lemp.Add(e);
            //    }
            //}
            //return Task.FromResult(lemp[0]);
        }

        public Task<Employee> GetEmployeeByEmpId(int EmpId)
        {
            Employee emp = null;
            foreach (Employee e in _db)
            {
                if (e.EmpId == EmpId)
                {
                    emp = e;break;
                }
            }
            return Task.FromResult(emp);
        }

        public Task<Employee> GetEmployeeByOnlyEmail(string Email)
        {
            Employee emp = null;
            foreach (Employee e in _db)
            {
                if (e.Email == Email)
                {
                    emp = e; break;
                }
            }
            return Task.FromResult(emp);
        }

        public Task<int> InsertEmployee(Employee Emp)
        {
            _db.Add(Emp);
            return Task.FromResult(SaveChanges());
        }

        public Task<int> UpdateEmployee(Employee Emp)
        {
            foreach(Employee e in _db)
            {
                if(e.EmpId == Emp.EmpId)
                {
                    e.EName = Emp.EName; e.Email = Emp.Email; 
                    e.Salary = Emp.Salary; e.Address = Emp.Address;
                    e.Phone = Emp.Phone;e.DeptNo = Emp.DeptNo;
                    e.Gender = Emp.Gender;e.Password = Emp.Password;
                    break;
                }
            }  
            return Task.FromResult(SaveChanges());
        }

        public int SaveChanges()
        {
            return 1;
        }

        public int TotalRecords()
        {
            return _db.Count;
        }
    }
}
