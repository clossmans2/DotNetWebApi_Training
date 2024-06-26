﻿using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class OfficeAssignment
    {
        [Key]
        public Guid InstructorId { get; set; }
        [MaxLength(50)]
        public string? Location { get; set; }
        public Instructor? Instructor { get; set; }
    }
}