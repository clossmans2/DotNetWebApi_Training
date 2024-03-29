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
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IServiceManager _service;

        public InstructorController(IServiceManager serviceManager) => _service = serviceManager;

        [HttpGet]

        public IActionResult GetInstructors()
        {
            var result = _service.Instructor.GetAllInstructors(trackChanges: false);
            return Ok(result);
        }

        [HttpGet("{id:guid}", Name = "InstructorById")]
        public IActionResult GetInstructor(Guid id)
        {
            var instructor = _service.Instructor.GetInstructor(id, trackChanges: false);
            return Ok(instructor);
        }

        [HttpPost]
        public IActionResult CreateInstructor([FromBody] InstructorForCreationDto instructor)
        {
            if (instructor == null)
            {
                return BadRequest("InstructorForCreationDto object is null");
            }

            var createdInstructor = _service.Instructor.CreateInstructor(instructor);
            return CreatedAtRoute("InstructorById", new { id = createdInstructor.Id }, createdInstructor);
        }
    }
}