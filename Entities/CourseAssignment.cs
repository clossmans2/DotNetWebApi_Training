using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class CourseAssignment
    {
        [ForeignKey(nameof(Instructor))]
        public Guid InstructorId { get; set; }
        [ForeignKey(nameof(Course))]
        public Guid CourseId { get; set; }
        public Instructor? Instructor { get; set; }
        public Course? Course { get; set; }
    }
}