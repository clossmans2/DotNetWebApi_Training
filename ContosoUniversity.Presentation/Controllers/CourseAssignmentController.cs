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
    public class CourseAssignmentController : ControllerBase
    {
        private readonly IServiceManager _service;

        public CourseAssignmentController(IServiceManager serviceManager) => _service = serviceManager;

        [HttpGet]

        public IActionResult GetCourseAssignments()
        {
            var result =  _service.CourseAssignment.GetAllCourseAssignments(trackChanges: false);
            return Ok(result);
        }

        [HttpGet("course/{id:guid}", Name = "CourseAssignmentsByCourseId")]
        public IActionResult GetCourseAssignmentsByCourseId(Guid id)
        {
            var result = _service.CourseAssignment.GetCourseAssignmentsByCourseId(id, trackChanges: false);
            return Ok(result);
        }

        [HttpGet("instructor/{id:guid}", Name = "CourseAssignmentsByInstructorId")]
        public IActionResult GetCourseAssignmentsByInstructorId(Guid id)
        {
            var result = _service.CourseAssignment.GetCourseAssignmentsByInstructorId(id, trackChanges: false);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateCourseAssignment([FromBody] CourseAssignmentDto courseAssignment)
        {
            if (courseAssignment == null)
                return BadRequest("CourseAssignmentDto object is null");

            var createdCourseAssignment = _service.CourseAssignment.CreateCourseAssignment(courseAssignment);
            return CreatedAtRoute("CourseAssignmentByInstructorId", new { instructorId = createdCourseAssignment.InstructorId }, createdCourseAssignment);
        }
    }
}