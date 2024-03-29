using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface ICourseService
    {
        IEnumerable<CourseDto> GetAllCourses(bool trackChanges);
        CourseDto GetCourse(Guid id, bool trackChanges);
        CourseDto CreateCourse(CourseForCreationDto course);
    }
}
