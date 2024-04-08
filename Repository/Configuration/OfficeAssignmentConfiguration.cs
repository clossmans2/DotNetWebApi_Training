using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class OfficeAssignmentConfiguration : IEntityTypeConfiguration<OfficeAssignment>
    {
        public void Configure(EntityTypeBuilder<OfficeAssignment> builder)
        {
            builder.HasData(
                new OfficeAssignment
                {
                    InstructorId = new Guid("2a12c3f2-fc7a-4bd2-9f66-21a9c79d1893"),
                    Location = "Smith 17"
                },
                new OfficeAssignment
                {
                    InstructorId = new Guid("63b92923-68a5-4053-9bf7-5e41c4fe1d91"),
                    Location = "Gowan 27"
                },
                new OfficeAssignment
                {
                    InstructorId = new Guid("e24a644d-9a45-4f66-966c-580fd191573a"),
                    Location = "Thompson 304"
                }
            );
        }
    }
}
