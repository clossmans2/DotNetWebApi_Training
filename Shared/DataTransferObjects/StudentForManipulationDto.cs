using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public abstract record StudentForManipulationDto
    {
        [Required(ErrorMessage = "First name is required.")]
        [MaxLength(60, ErrorMessage = "First name cannot be longer than 60 characters.")]
        public string? FirstMidName { get; init; }

        [Required(ErrorMessage = "Last name is required.")]
        [MaxLength(60, ErrorMessage = "Last name cannot be longer than 60 characters.")]
        public string? LastName { get; init; }
        [Required(ErrorMessage = "Email is a required field.")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; init; }

        [DataType(DataType.Date)]
        public DateTime? EnrollmentDate { get; init; }
    }
}
