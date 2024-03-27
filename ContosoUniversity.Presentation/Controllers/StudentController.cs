using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace ContosoUniversity.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IServiceManager _service;

        public StudentController(IServiceManager serviceManager) => _service = serviceManager;


        [HttpGet]
        public IActionResult GetStudents()
        {
            try
            {
                var students = _service.Student.GetAllStudents(trackChanges: false);
                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
