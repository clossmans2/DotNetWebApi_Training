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
    public class OfficeAssignmentController : ControllerBase
    {
        private readonly IServiceManager _service;

        public OfficeAssignmentController(IServiceManager serviceManager) => _service = serviceManager;

        [HttpGet]

        public IActionResult GetOfficeAssignments()
        {
            var result = _service.OfficeAssignment.GetAllOfficeAssignments(trackChanges: false);
            return Ok(result);
        }

        [HttpGet("{id:guid}", Name = "OfficeAssignmentById")]
        public IActionResult GetOfficeAssignment(Guid id)
        {
            var officeAssignment = _service.OfficeAssignment.GetOfficeAssignment(id, trackChanges: false);
            return Ok(officeAssignment);
        }

        [HttpPost]
        public IActionResult CreateOfficeAssignment([FromBody] OfficeAssignmentDto officeAssignment)
        {
            if (officeAssignment == null)
                return BadRequest("OfficeAssignmentDto object is null");

            var createdOfficeAssignment = _service.OfficeAssignment.CreateOfficeAssignment(officeAssignment);
            return CreatedAtRoute("OfficeAssignmentById", new { id = createdOfficeAssignment.InstructorId }, createdOfficeAssignment);
        }
    }
}