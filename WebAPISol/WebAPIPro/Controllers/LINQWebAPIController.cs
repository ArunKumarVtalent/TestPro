using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIPro.DataAccess.IRepository;
using WebAPIPro.Filters;
using WebAPIPro.Models;
using System.Linq;

namespace WebAPIPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LINQWebAPIController : ControllerBase
    {
        public IEmpRepository IEmpRef;
        public LINQWebAPIController(IEmpRepository _IEmpRef)
        {
            IEmpRef = _IEmpRef;
        }

        [HttpGet]
        [Route("getEmpList")]
        public async Task<List<Employee>> getEmpList()
        {
            return await IEmpRef.AllEmployees();
        }

        [HttpGet]
        [Route("AllEmployees")]
        public async Task<IActionResult> AllEmployees()
        {
            try
            {
                var ListEmps = await getEmpList();
                if (ListEmps.Count > 0)
                {
                    return Ok(ListEmps);
                }
                else
                {
                    return NotFound("Records are not available in database...!");
                }
            }
            catch (Exception ex)
            {
                // Log : Error Information [Exception Logging]
                return BadRequest("Somthing Went Wrong...!\n" + "Issue : " + ex.Message + ".\nWe will soleve this issue soon...!");
            }
        }

        [HttpGet]
        [Route("EmployeeByEmpId")]
        public async Task<IActionResult> EmployeeByEmpId(int EmpId)
        {
            try
            {
                var emp = (from x in await getEmpList() where x.EmpId == EmpId select x).SingleOrDefault();
                if (emp != null)
                {
                    return Ok(emp);
                }
                else
                {
                    return NotFound("Records are not available in database...!");
                }
            }
            catch (Exception ex)
            {
                // Log : Error Information [Exception Logging]
                return BadRequest("Somthing Went Wrong...!\n" + "Issue : " + ex.Message + ".\nWe will soleve this issue soon...!");
            }
        }

        [HttpGet]
        [Route("EmployeeByEmailAndPassword")]
        public async Task<IActionResult> EmployeeByEmailAndPassword(string Email, string Password)
        {
            try
            {
                var emp = (from x in await getEmpList() where x.Email == Email && x.Password == Password select x).SingleOrDefault();
                if (emp != null)
                {
                    return Ok(emp);
                }
                else
                {
                    return NotFound("Records are not available in database...!");
                }
            }
            catch (Exception ex)
            {
                // Log : Error Information [Exception Logging]
                return BadRequest("Somthing Went Wrong...!\n" + "Issue : " + ex.Message + ".\nWe will soleve this issue soon...!");
            }
        }

        [HttpGet]
        [Route("EmployeeByDeptNo")]
        public async Task<IActionResult> EmployeeByDeptNo(int DeptNo)
        {
            try
            {
                var empList = (from x in await getEmpList() where x.DeptNo == DeptNo select x).ToList();
                if (empList.Count != 0)
                {
                    return Ok(empList);
                }
                else
                {
                    return NotFound("Records are not available in database...!");
                }
            }
            catch (Exception ex)
            {
                // Log : Error Information [Exception Logging]
                return BadRequest("Somthing Went Wrong...!\n" + "Issue : " + ex.Message + ".\nWe will soleve this issue soon...!");
            }
        }

        [HttpGet]
        [Route("EmployeeSalaryDesendingOrder")]
        public async Task<IActionResult> EmployeeSalaryDesendingOrder()
        {
            try
            {
                var empList = (from x in await getEmpList() orderby x.Salary descending select x).ToList();
                if (empList.Count != 0)
                {
                    return Ok(empList);
                }
                else
                {
                    return NotFound("Records are not available in database...!");
                }
            }
            catch (Exception ex)
            {
                // Log : Error Information [Exception Logging]
                return BadRequest("Somthing Went Wrong...!\n" + "Issue : " + ex.Message + ".\nWe will soleve this issue soon...!");
            }
        }

        [HttpGet]
        [Route("EmployeeWithSomeColumsn")]
        public async Task<IActionResult> EmployeeWithSomeColumsn()
        {
            try
            {
                var empList = (from x in await getEmpList() select new { x.EmpId, x.EName, x.Gender, x.Salary, x.Address }).ToList();
                if (empList.Count != 0)
                {
                    return Ok(empList);
                }
                else
                {
                    return NotFound("Records are not available in database...!");
                }
            }
            catch (Exception ex)
            {
                // Log : Error Information [Exception Logging]
                return BadRequest("Somthing Went Wrong...!\n" + "Issue : " + ex.Message + ".\nWe will soleve this issue soon...!");
            }
        }

        [HttpGet]
        [Route("EmployeeWithSomeColumsnWithAliasName")]
        public async Task<IActionResult> EmployeeWithSomeColumsnWithAliasName()
        {
            try
            {
                var empList = (from x in await getEmpList() select new { Employee_ID = x.EmpId, Name = x.EName, x.Gender, x.Salary, x.Address }).ToList();
                if (empList.Count != 0)
                {
                    return Ok(empList);
                }
                else
                {
                    return NotFound("Records are not available in database...!");
                }
            }
            catch (Exception ex)
            {
                // Log : Error Information [Exception Logging]
                return BadRequest("Somthing Went Wrong...!\n" + "Issue : " + ex.Message + ".\nWe will soleve this issue soon...!");
            }
        }
    }
}
