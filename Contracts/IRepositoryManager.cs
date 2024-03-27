using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        IStudentRepository Student { get; }
        ICourseRepository Course { get; }
        IInstructorRepository Instructor { get; }
        IEnrollmentRepository Enrollment { get; }
        ICourseAssignmentRepository CourseAssignment { get; }
        IOfficeAssignmentRepository OfficeAssignment { get; }
        IDepartmentRepository Department { get; }
        void Save();
    }
}
