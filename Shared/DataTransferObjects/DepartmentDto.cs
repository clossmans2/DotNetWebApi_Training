using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record DepartmentDto {
        public Guid Id { get; init; }
        public string? Name { get; init; }
        public decimal Budget { get; init; }
        public Guid InstructorId { get; init; }
    }

}
