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
    [Route("api/student/{studentId:guid}/enrollment")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IServiceManager _service;

        public EnrollmentController(IServiceManager serviceManager) => _service = serviceManager;

        [HttpGet]

        public IActionResult GetAllEnrollments(Guid studentId)
        {
            var enrollments = _service.Enrollment.GetAllEnrollments(studentId, trackChanges: false);
            return Ok(enrollments);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetEnrollment(Guid studentId, Guid id)
        {
            var enrollment = _service.Enrollment.GetEnrollment(studentId, id, trackChanges: false);
            return Ok(enrollment);
        }

        [HttpPost]
        public IActionResult CreateEnrollment(Guid studentId, [FromBody] EnrollmentForCreationDto enrollment)
        {
            if (enrollment == null)
                return BadRequest("EnrollmentForCreationDto object is null");

            var createdEnrollment = _service.Enrollment.CreateEnrollment(enrollment);
            return CreatedAtRoute("EnrollmentById", new { id = createdEnrollment.Id }, createdEnrollment);
        }
    }
}