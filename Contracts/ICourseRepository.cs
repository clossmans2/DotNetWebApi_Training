using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Contracts
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAllCourses(bool trackChanges);
        Course GetCourse(Guid courseId, bool trackChanges);
        void CreateCourse(Course course);
    }
}
