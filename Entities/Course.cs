using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Course
    {
        [Column("CourseId")]
        public Guid Id { get; set; }
        [MaxLength(50)]
        [MinLength(4)]
        public string? Title { get; set; }

        [Range(0, 5)]
        public int Credits { get; set; }

        [ForeignKey(nameof(Department))]
        public Guid DepartmentId { get; set; }
        public Department? Department { get; set; }

        public ICollection<Enrollment>? Enrollments { get; set; }
        public ICollection<CourseAssignment>? CourseAssignments { get; set; }   

    }
}