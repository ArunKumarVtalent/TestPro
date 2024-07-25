using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebAPIPro.DataAccess;
using WebAPIPro.DataAccess.IRepository;
using WebAPIPro.Models;

namespace WebAPIPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeptWebAPIController : ControllerBase
    {
        public IDeptRepository IDeptRef;

        public DeptWebAPIController(IDeptRepository _IDeptRef)
        {
            IDeptRef = _IDeptRef;
        }


        [HttpPost]
        [Route("InsertDepartment")]
        public async Task<IActionResult> InsertDepartment([FromBody] Department Dept)
        {
            try
            {
                var count = await IDeptRef.InsertDepartment(Dept);
                if (count > 0)
                {
                    return Ok(count);
                }
                else
                {
                    return BadRequest("Record is Not Inserted...!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Somthing Went Wrong...!\n" + "Issue : " + ex.Message + ".\nWe will soleve this issue soon...!");
            }
        }

        [HttpGet]
        [Route("AllDepartments")]
        public async Task<IActionResult> AllDepartments()
        {
            try
            {
                var ListDept = await IDeptRef.AllDepartments();
                if (ListDept.Count > 0)
                {
                    return Ok(ListDept);
                }
                else
                {
                    return NotFound("Records are not available in the database...!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Somthing Went Wrong...!\n" + "Issue : " + ex.Message + ".\nWe will soleve this issue soon...!");
            }
        }

        [HttpGet]
        [Route("DepartmentByDeptNo")]
        public async Task<IActionResult> DepartmentByDeptNo(int DeptNo)
        {
            try
            {
                var Dept = await IDeptRef.GetDepartmentByDeptNo(DeptNo);
                if (Dept != null)
                {
                    return Ok(Dept);
                }
                else
                {
                    return NotFound("Record is not available in the database with DeptNo = '" + DeptNo + "'...!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Somthing Went Wrong...!\n" + "Issue : " + ex.Message + ".\nWe will soleve this issue soon...!");
            }
        }

        [HttpGet]
        [Route("DepartmentByLocation")]
        public async Task<IActionResult> DepartmentByLocation(string Location)
        {
            try
            {
                var ListDept = await IDeptRef.GetDepartmentByLocation(Location);
                if (ListDept.Count > 0)
                {
                    return Ok(ListDept);
                }
                else
                {
                    return NotFound("Records are not available in the database with Location = '" + Location + "'...!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Somthing Went Wrong...!\n" + "Issue : " + ex.Message + ".\nWe will soleve this issue soon...!");
            }
        }

        [HttpPut]
        [Route("UpdateDepartment")]
        public async Task<IActionResult> UpdateDepartment([FromBody] Department Dept)
        {
            try
            {
                var count = await IDeptRef.UpdateDepartment(Dept);
                if (count > 0)
                {
                    return Ok(count);
                }
                else
                {
                    return BadRequest("Record is Not Updated...!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Somthing Went Wrong...!\n" + "Issue : " + ex.Message + ".\nWe will soleve this issue soon...!");
            }
        }

        [HttpDelete]
        [Route("DeleteDepartment")]
        public async Task<IActionResult> DeleteDepartment(int DeptNo)
        {
            try
            {
                var count = await IDeptRef.DeleteDepartment(DeptNo);
                if (count > 0)
                {
                    return Ok(count);
                }
                else
                {
                    return BadRequest("Record is Not Deleted...!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Somthing Went Wrong...!\n" + "Issue : " + ex.Message + ".\nWe will soleve this issue soon...!");
            }
        }
    }
}
