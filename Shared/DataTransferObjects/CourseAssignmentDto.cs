using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record CourseAssignmentDto
    {
        public Guid InstructorId { get; init; }
        public Guid CourseId { get; init; }
    }

}
