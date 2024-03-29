﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record StudentWithEnrollmentsDto
    {
        public Guid Id { get; init; }
        public string? FirstMidName { get; init; }
        public string? LastName { get; init; }
        public string? Email { get; init; }
        public DateTime? EnrollmentDate { get; init; }

        public IEnumerable<EnrollmentDto>? Enrollments { get; init; }
    }
}
