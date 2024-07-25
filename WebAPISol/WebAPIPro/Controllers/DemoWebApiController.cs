using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAPIPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoWebApiController : ControllerBase
    {
        [HttpGet]
        [Route("Addition")]
        public IActionResult Addition(int x, int y)
        {
            try
            {
                return Ok(x + y);
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }
    }
}
