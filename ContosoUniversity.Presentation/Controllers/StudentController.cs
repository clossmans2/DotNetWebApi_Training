using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Authorization;

namespace ContosoUniversity.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController] // Attribute routing, Auto 400 response, binding source parameter, multi-part/form-data inference, problem details for status codes
    public class StudentController : ControllerBase
    {
        private readonly IServiceManager _service;

        public StudentController(IServiceManager serviceManager) => _service = serviceManager;


        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _service.Student.GetAllStudentsAsync(trackChanges: false);
            return Ok(students);
        }

        [HttpGet("{id:guid}", Name = "StudentById")]
        public async Task<IActionResult> GetStudent(Guid id)
        {
            var student = await _service.Student.GetStudentAsync(id, trackChanges: false);
            return Ok(student);
            
        }
        

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] StudentForCreationDto student)
        {
            if (student == null)
                return BadRequest("StudentForCreationDto object is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            
            var createdStudent = await _service.Student.CreateStudentAsync(student);
            return CreatedAtRoute("StudentById", new { id = createdStudent.Id }, createdStudent);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            await _service.Student.DeleteStudentAsync(id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateStudent(Guid id, [FromBody] StudentForUpdateDto student)
        {
            if (student == null)
                return BadRequest("StudentForUpdateDto object is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _service.Student.UpdateStudentAsync(id, student, trackChanges: true);
            return NoContent();
        }

        /// <summary>
        /// Patch Operations
        /// Add, Replace, Remove
        /// Copy, Move, Test
        /// Properties within a Patch Request:
        /// op: operation, path: path to the property, value: value to be used
        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> PartiallyUpdateStudent(Guid id, [FromBody] JsonPatchDocument<StudentForUpdateDto> patchDocument)
        {
            if (patchDocument is null)
                return BadRequest("patchDocument object sent from client is null");

            var result = await _service.Student.GetStudentForPatchAsync(id, trackChanges: true);
            patchDocument.ApplyTo(result.studentForUpdate);

            TryValidateModel(result.studentForUpdate);

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _service.Student.SaveChangesForPatchAsync(result.studentForUpdate, result.studentEntity);

            return NoContent();
        }
    }
}
