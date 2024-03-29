using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record CourseForCreationDto
    {
        public string? Title { get; init; }
        public int Credits { get; init; }
        public Guid DepartmentId { get; init; }
    }
}
