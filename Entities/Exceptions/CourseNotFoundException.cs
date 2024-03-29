using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class CourseNotFoundException : NotFoundException
    {
        public CourseNotFoundException(Guid courseId) 
            : base($"The course with the id: {courseId} was not found in the database")
        {
        }
    }
}
