using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IServiceManager
    {
        IStudentService Student { get; }
        ICourseService Course { get; }
        IInstructorService Instructor { get; }
        IDepartmentService Department { get; }
        IOfficeAssignmentService OfficeAssignment { get; }
        ICourseAssignmentService CourseAssignment { get; }
        IEnrollmentService Enrollment { get; }
    }
}
