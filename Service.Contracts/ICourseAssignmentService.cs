using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface ICourseAssignmentService
    {
        IEnumerable<CourseAssignmentDto> GetAllCourseAssignments(bool trackChanges);
        IEnumerable<CourseAssignmentDto> GetCourseAssignmentsByCourseId(Guid courseId, bool trackChanges);
        IEnumerable<CourseAssignmentDto> GetCourseAssignmentsByInstructorId(Guid instructorId, bool trackChanges);
        CourseAssignmentDto GetCourseAssignment(Guid courseId, Guid instructorId, bool trackChanges);
        
        
        CourseAssignmentDto CreateCourseAssignment(CourseAssignmentDto courseAssignment);
        
    }
}
