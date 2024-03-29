using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record DepartmentForCreationDto
    {
        public string? Name { get; init; }
        public decimal Budget { get; init; }
        public DateTime? StartDate { get; init; }
        public Guid? InstructorId { get; init; }
    }
}
