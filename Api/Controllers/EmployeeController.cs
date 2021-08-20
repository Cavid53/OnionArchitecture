using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.Interfaces;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult GetEmployee(int id)
        {
            var result = _employeeService.GetEmployee(id);
            if(result != null)
            {
                return Ok(result);
            }

            return BadRequest("No content");

        }
      
    }
}
