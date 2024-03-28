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
    public class CourseController : ControllerBase
    {
        private readonly IServiceManager _service;

        public CourseController(IServiceManager serviceManager) => _service = serviceManager;

        [HttpGet]

        public async Task<IActionResult> GetAllCourses()
        {
            try
            {
                var result = _service.Course.GetAllCourses(trackChanges: false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}