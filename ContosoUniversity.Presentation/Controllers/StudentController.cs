using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace ContosoUniversity.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController] // Attribute routing, Auto 400 response, binding source parameter, multi-part/form-data inference, problem details for status codes
    public class StudentController : ControllerBase
    {
        private readonly IServiceManager _service;

        public StudentController(IServiceManager serviceManager) => _service = serviceManager;


        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = _service.Student.GetAllStudents(trackChanges: false);
            return Ok(students);
        }

        [HttpGet("{id:guid}", Name = "StudentById")]
        public IActionResult GetStudent(Guid id)
        {
            var student = _service.Student.GetStudent(id, trackChanges: false);
            return Ok(student);
            
        }

        [HttpPost]
        public IActionResult CreateStudent([FromBody] StudentForCreationDto student)
        {
            if (student == null)
                return BadRequest("StudentForCreationDto object is null");
            
            var createdStudent = _service.Student.CreateStudent(student);
            return CreatedAtRoute("StudentById", new { id = createdStudent.Id }, createdStudent);
        }

    }
}
