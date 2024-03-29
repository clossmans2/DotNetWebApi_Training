﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record EnrollmentForCreationDto
    {
        public Guid CourseId { get; init; }
        public Guid StudentId { get; init; }
    }
}
