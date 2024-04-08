using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;

namespace Repository
{
    public class CourseAssignmentRepository : RepositoryBase<CourseAssignment>, ICourseAssignmentRepository
    {
        public CourseAssignmentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateCourseAssignment(CourseAssignment courseAssignment) => Create(courseAssignment);


        public IEnumerable<CourseAssignment> GetAllCourseAssignments(bool trackChanges) => 
            FindAll(trackChanges).OrderBy(s => s.CourseId).ToList();

        public CourseAssignment GetCourseAssignment(Guid courseId, Guid instructorId, bool trackChanges) =>
               FindByCondition(
                   i => i.CourseId.Equals(courseId) 
                   && i.InstructorId.Equals(instructorId), trackChanges).SingleOrDefault();

        public IEnumerable<CourseAssignment> GetCourseAssignmentsByCourseId(Guid courseId, bool trackChanges)
        {
            var courseAssignments = FindByCondition(i => i.CourseId.Equals(courseId), trackChanges).ToList();
            return courseAssignments;
        }

        public IEnumerable<CourseAssignment> GetCourseAssignmentsByInstructorId(Guid instructorId, bool trackChanges)
        {
            var courseAssignments = FindByCondition(i => i.InstructorId.Equals(instructorId), trackChanges).ToList();
            return courseAssignments;
        }
    }
}
