using Dot_Net_7.Models;
using Dot_Net_7.Services.EmployeeService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Dot_Net_7.Controllers
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
        [Route("GetAllEmployee")]
        public async Task<IActionResult> GetAllEmployee()
        {
            var result =await _employeeService.GetAllEmployes();
            if(result is null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetSingleEmployee/{id}")]
        public async Task<IActionResult> GetSingleEmployee(int id)
        {
            var result =await _employeeService.GetSingleEmployee(id);
            if (result is null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> AddEmployee(Employee request)
        {
            var result = await _employeeService.AddEmployes(request);
            if (result is null)
                return Problem("Sorry, Something went wrong");
            return Ok(result);
        }

        [HttpPatch]
        [Route("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee(Employee request)
        {
            var result =await _employeeService.UpdateEmployes(request);
            if (result is null)
                return NotFound();
            return Ok(result);
        }

        [HttpPatch]
        [Route("DeleteEmployee/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var result =await _employeeService.DeleteEmployes(id);
            if (result is null)
                return NotFound();
           return Ok(result);
        }
    }
}
