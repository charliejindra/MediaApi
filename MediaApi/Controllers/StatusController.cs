using MediaApi.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaApi.Controllers
{
    public class StatusController : ControllerBase
    {

        ISystemTime Clock;

        public StatusController(ISystemTime clock)
        {
            Clock = clock;
        }

        // GET /status
        [HttpGet("status")]
        public ActionResult<StatusResponse> GetStatus()
        {
            var response = new StatusResponse
            {
                Message = "everything is cool",
                CreatedAt = Clock.GetCurrent()
            };
            return Ok(response); // returns a 200
        }

        // GET /sayhi/name
        [HttpGet("sayhi/{name:minlength(3)}")]
        public IActionResult SayHi(string name)
        {
            return Ok($"Howdy, {name}!");
        }

        // GET /employees?department=DEV
        [HttpGet("employees")]
        public IActionResult GetEmployees(string department = "All")
        {
            return Ok($"Getting you employees from dept {department}");
        }

        // hiring an employee
        [HttpPost("employees")]
        public IActionResult HireEmployee([FromBody] Hiringrequest employeeToHire)
        {
            return Ok($"hiring {employeeToHire.FirstName} as a {employeeToHire.Department}");
        }

    }

    public class StatusResponse
    {
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class Hiringrequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal StartingSalary { get; set; }
        public string Department { get; set; }
    }
}
