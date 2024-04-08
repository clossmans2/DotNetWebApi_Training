using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;

namespace Repository
{
    public class CourseRepository : RepositoryBase<Course>, ICourseRepository
    {
        public CourseRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateCourse(Course course) => Create(course);

        public IEnumerable<Course> GetAllCourses(bool trackChanges) => FindAll(trackChanges).OrderBy(c => c.Title).ToList();

        public Course GetCourse(Guid courseId, bool trackChanges) =>
            FindByCondition(c => c.Id.Equals(courseId), trackChanges).SingleOrDefault();
    }
}
