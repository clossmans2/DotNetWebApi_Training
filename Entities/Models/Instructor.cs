using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Instructor : Person
    {
        [DataType(DataType.Date)]
        public DateTime? HireDate { get; set; }

        public ICollection<CourseAssignment>? CourseAssignments { get; set; }
        public OfficeAssignment? OfficeAssignment { get; set; }

    }
}