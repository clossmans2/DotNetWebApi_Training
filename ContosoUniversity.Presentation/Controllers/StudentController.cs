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


        /// <summary>
        /// Gets all students in the database
        /// </summary>
        /// <returns>A list of all the students</returns>
        /// <response code="200">Returns a list of students</response>
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _service.Student.GetAllStudentsAsync(trackChanges: false);
            return Ok(students);
        }


        /// <summary>
        /// Gets a single student using the student's id
        /// </summary>
        /// <param name="id">GUID that identifies the student record</param>
        /// <returns>A single student object</returns>
        /// <response code="200">Returns the student object</response>
        /// <response code="400">If the student id is null</response>
        /// <response code="404">If the student object is not found</response>
        [HttpGet("{id:guid}", Name = "StudentById")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetStudent(Guid id)
        {
            var student = await _service.Student.GetStudentAsync(id, trackChanges: false);
            return Ok(student);
            
        }
        

        /// <summary>
        /// Creates a new student in the database
        /// </summary>
        /// <param name="student">An object containing firstMidName, lastName, email, and enrollmentDate values</param>
        /// <returns>The newly created student object</returns>
        /// <response code="201">Returns the newly created student object</response>
        /// <response code="400">If the student object is null</response>
        /// <response code="422">If the model state is invalid</response>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        public async Task<IActionResult> CreateStudent([FromBody] StudentForCreationDto student)
        {
            if (student == null)
                return BadRequest("StudentForCreationDto object is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            
            var createdStudent = await _service.Student.CreateStudentAsync(student);
            return CreatedAtRoute("StudentById", new { id = createdStudent.Id }, createdStudent);
        }

        /// <summary>
        /// Deletes a student from the database
        /// </summary>
        /// <param name="id">GUID used to identify the student</param>
        /// <response code="204">If the delete action was successful</response>
        /// <response code="404">If the student object is not found</response>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            await _service.Student.DeleteStudentAsync(id, trackChanges: false);
            return NoContent();
        }

        /// <summary>
        /// Updates a student in the database
        /// </summary>
        /// <param name="id">A GUID used to identify the student record to update</param>
        /// <param name="student">The updated student object to save to the database</param>
        /// <response code="204">If the update action was successful</response>
        /// <response code="400">If the student object is null</response>
        /// <response code="422">If the model state is invalid</response>
        [HttpPut("{id:guid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
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
        /// Uses a patch document to update a student in the database
        /// Patch Operations
        /// Add, Replace, Remove
        /// Copy, Move, Test
        /// Properties within a Patch Request:
        /// op: operation, path: path to the property, value: value to be used
        /// </summary>
        /// <param name="id">GUID used to identify the student record to update</param>
        /// <param name="patchDocument">A JSON patch document containing the operations to perform</param>
        /// <response code="204">If the update action was successful</response>
        /// <response code="400">If the patchDocument object is null</response>
        /// <response code="422">If the model state is invalid</response>
        [HttpPatch("{id:guid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
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
