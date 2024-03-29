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
    public class CourseController : ControllerBase
    {
        private readonly IServiceManager _service;

        public CourseController(IServiceManager serviceManager) => _service = serviceManager;

        [HttpGet]

        public IActionResult GetCourses()
        {
            var result = _service.Course.GetAllCourses(trackChanges: false);
            return Ok(result);
        }

        [HttpGet("{id:guid}", Name = "CourseById")]
        public IActionResult GetCourse(Guid id)
        {
            var course = _service.Course.GetCourse(id, trackChanges: false);
            return Ok(course);
        }

        [HttpPost]
        public IActionResult CreateCourse([FromBody] CourseForCreationDto course)
        {
            if (course == null)
                return BadRequest("CourseForCreationDto object is null");

            var createdCourse = _service.Course.CreateCourse(course);
            return CreatedAtRoute("CourseById", new { id = createdCourse.Id }, createdCourse);
        }
    }
}