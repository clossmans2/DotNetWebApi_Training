using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class CourseAssignmentNotFoundException : NotFoundException
    {
        public CourseAssignmentNotFoundException(Guid instructorId, Guid courseId) 
            : base($"The course assignment with the instructor id: {instructorId} and the course id: {courseId} was not found in the database.")
        {
            
        }
    }
}
