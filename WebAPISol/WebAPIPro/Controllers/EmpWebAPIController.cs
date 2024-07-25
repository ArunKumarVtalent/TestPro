using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebAPIPro.DataAccess;
using WebAPIPro.DataAccess.IRepository;
using WebAPIPro.Filters;
using WebAPIPro.Models;

namespace WebAPIPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpWebAPIController : ControllerBase
    {
        public IEmpRepository IEmpRef;
        public EmpWebAPIController(IEmpRepository _IEmpRef)
        {
            IEmpRef = _IEmpRef;
        }

        /// <summary>
        /// This method is used to insert a new employee record into the database
        /// </summary>
        /// <param name="Emp">'Emp' is a Employee Model Object</param>
        /// <returns>It Return the db effected save changed count</returns>
        [HttpPost]
        [Route("InsertEmployee")]
        public async Task<IActionResult> InsertEmployee(Employee Emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var count = await IEmpRef.InsertEmployee(Emp);
                    if (count > 0)
                    {
                        return Ok(count);
                    }
                    else
                    {
                        return BadRequest("Record is not inserted...!");
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }

            }
            catch (Exception ex)
            {
                return BadRequest("Somthing Went Wrong...!\n" + "Issue : " + ex.Message + ".\nWe will soleve this issue soon...!");
            }
        }

        /// <summary>
        /// This web api is used to read all the available employee data from database
        /// </summary>
        /// <returns>It returns a employees collection object</returns>
        [HttpGet]
        [Route("AllEmployees")]
        [MyActionFilters]
        [MyResultFilters]
        [MyExceptionFilter]
        public async Task<IActionResult> AllEmployees()
        {
            //HttpContext.Session.SetString("Name", "Raj");

            //try
            //{
            //throw new DivideByZeroException();
            //throw new FormatException();
            var ListEmps = await IEmpRef.AllEmployees();
            if (ListEmps.Count > 0)
            {
                return Ok(ListEmps);
            }
            else
            {
                return NotFound("Records are not available in database...!");
            }
            //}
            //catch (Exception ex)
            //{
            //    // Log : Error Information [Exception Logging]
            //    return BadRequest("Somthing Went Wrong...!\n" + "Issue : " + ex.Message + ".\nWe will soleve this issue soon...!");
            //}
        }

        [HttpGet]
        [Route("EmployeeByEmpId")]
        public async Task<IActionResult> EmployeeByEmpId(int EmpId)
        {
            try
            {
                var Emp = await IEmpRef.GetEmployeeByEmpId(EmpId);
                if (Emp != null)
                {
                    return Ok(Emp);
                }
                else
                {
                    return NotFound("Record is not available in database...!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Somthing Went Wrong...!\n" + "Issue : " + ex.Message + ".\nWe will soleve this issue soon...!");
            }
        }

        [HttpGet]
        [Route("EmployeeByDeptNo")]
        public async Task<IActionResult> EmployeeByDeptNo(int DeptNo)
        {
            try
            {
                var EmpList = await IEmpRef.GetEmployeeByDeptNo(DeptNo);
                if (EmpList.Count != 0)
                {
                    return Ok(EmpList);
                }
                else
                {
                    return NotFound("Records are not available in database...!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Somthing Went Wrong...!\n" + "Issue : " + ex.Message + ".\nWe will soleve this issue soon...!");
            }
        }

        [HttpGet]
        [Route("EmployeeByEmailAndPassword")]
        public async Task<IActionResult> EmployeeByEmailAndPassword(string Email, string Password)
        {
            try
            {
                var Emp = await IEmpRef.GetEmployeeByEmailAndPassword(Email, Password);
                if (Emp != null)
                {
                    return Ok(Emp);
                }
                else
                {
                    return NotFound("Record is not available in database...!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Somthing Went Wrong...!\n" + "Issue : " + ex.Message + ".\nWe will soleve this issue soon...!");
            }
        }

        [HttpPut]
        [Route("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee(Employee Emp)
        {
            try
            {
                var count = await IEmpRef.UpdateEmployee(Emp);
                if (count > 0)
                {
                    return Ok(count);
                }
                else
                {
                    return BadRequest("Record is not updated...!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Somthing Went Wrong...!\n" + "Issue : " + ex.Message + ".\nWe will soleve this issue soon...!");
            }
        }

        [HttpDelete]
        [Route("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(int EmpId)
        {
            try
            {
                var count = await IEmpRef.DeleteEmployee(EmpId);
                if (count > 0)
                {
                    return Ok(count);
                }
                else
                {
                    return BadRequest("Record is not deleted...!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Somthing Went Wrong...!\n" + "Issue : " + ex.Message + ".\nWe will soleve this issue soon...!");
            }
        }

        [HttpDelete]
        [Route("DeleteAllEmployee")]
        public async Task<IActionResult> DeleteAllEmployee()
        {
            try
            {
                var count = await IEmpRef.DeleteAllEmployee();
                if (count > 0)
                {
                    return Ok(count);
                }
                else
                {
                    return BadRequest("Records are not deleted...!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Somthing Went Wrong...!\n" + "Issue : " + ex.Message + ".\nWe will soleve this issue soon...!");
            }
        }
    }
}
