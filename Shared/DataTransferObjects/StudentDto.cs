using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record StudentDto 
    {
        public Guid Id { get; init; }
        public string? FullName { get; init; }
        public string? Email { get; init; }
    }

}
