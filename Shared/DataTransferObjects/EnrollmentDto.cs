﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record EnrollmentDto
    {
        public Guid Id { get; init; } 
        public Guid StudentId { get; init; }
        public Guid CourseId { get; init; }
        
    }

}
