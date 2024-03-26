using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Department
    {
        [Column("DepartmentId")]
        public Guid Id { get; set; }
        [MaxLength(50)]
        [MinLength(3)]
        public string? Name { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Budget { get; set; }
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
        [ForeignKey(nameof(Instructor))]
        public Guid? InstructorId { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
        public Instructor? Administrator { get; set; }
        public ICollection<Course>? Courses { get; set; }
    }
}