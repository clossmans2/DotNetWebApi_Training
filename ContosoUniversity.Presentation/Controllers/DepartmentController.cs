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
    public class DepartmentController : ControllerBase
    {
        private readonly IServiceManager _service;

        public DepartmentController(IServiceManager serviceManager) => _service = serviceManager;

        [HttpGet]

        public IActionResult GetDepartments()
        {
            var result = _service.Department.GetAllDepartments(trackChanges: false);
            return Ok(result);
        }

        [HttpGet("{id:guid}", Name = "DepartmentById")]
        public IActionResult GetDepartment(Guid id)
        {
            var department = _service.Department.GetDepartment(id, trackChanges: false);
            return Ok(department);
        }

        [HttpPost]
        public IActionResult CreateDepartment([FromBody] DepartmentForCreationDto department)
        {
            if (department == null)
            {
                return BadRequest("DepartmentForCreationDto object is null");
            }

            var createdDepartment = _service.Department.CreateDepartment(department);
            return CreatedAtRoute("DepartmentById", new { id = createdDepartment.Id }, createdDepartment);
        }
    }
}