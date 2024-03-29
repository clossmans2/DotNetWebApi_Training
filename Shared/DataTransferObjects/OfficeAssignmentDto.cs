using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record OfficeAssignmentDto
    {
        public Guid InstructorId { get; init; }
        public string? Location { get; init; }
    }
}
