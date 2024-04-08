using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface ICourseAssignmentRepository
    {
        IEnumerable<CourseAssignment> GetAllCourseAssignments(bool trackChanges);
        IEnumerable<CourseAssignment> GetCourseAssignmentsByCourseId(Guid courseId, bool trackChanges);
        IEnumerable<CourseAssignment> GetCourseAssignmentsByInstructorId(Guid instructorId, bool trackChanges);
        CourseAssignment GetCourseAssignment(Guid courseId, Guid instructorId, bool trackChanges);
        void CreateCourseAssignment(CourseAssignment courseAssignment);
    }
}
