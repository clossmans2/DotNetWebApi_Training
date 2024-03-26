using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public enum Grade
    {
        A,
        B, 
        C,
        D,
        F
    }
    public class Enrollment
    {
        [Column("EnrollmentId")]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Course))]
        public Guid CourseId { get; set; }

        [ForeignKey(nameof(Student))]
        public Guid StudentId { get; set; }
        public Grade? Grade { get; set; } = null;

        public Course? Course { get; set; }
        public Student? Student { get; set; }
    }
}