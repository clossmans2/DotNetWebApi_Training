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
    public class DepartmentController : ControllerBase
    {
        private readonly IServiceManager _service;

        public DepartmentController(IServiceManager serviceManager) => _service = serviceManager;

        [HttpGet]

        public IActionResult GetAllDepartments()
        {
            try
            {
                var result = _service.Department.GetAllDepartments(trackChanges: false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}