using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class CourseAssignmentConfiguration : IEntityTypeConfiguration<CourseAssignment>
    {
        public void Configure(EntityTypeBuilder<CourseAssignment> builder)
        {
            builder.HasData(
                new CourseAssignment
                {
                    CourseId = new Guid("ba22eae4-8282-483d-8d43-e3b47bd105d4"),
                    InstructorId = new Guid("e24a644d-9a45-4f66-966c-580fd191573a")
                },
                new CourseAssignment
                {
                    CourseId = new Guid("ba22eae4-8282-483d-8d43-e3b47bd105d4"),
                    InstructorId = new Guid("63b92923-68a5-4053-9bf7-5e41c4fe1d91")
                },
                new CourseAssignment
                {
                    CourseId = new Guid("854f1892-e043-49e0-9573-5544e833a8d3"),
                    InstructorId = new Guid("455dfcc1-552a-45fa-b94e-d973906490cc")
                },
                new CourseAssignment
                {
                    CourseId = new Guid("ad18dff5-58ee-4e02-ba83-ffd1c8a1f56e"),
                    InstructorId = new Guid("455dfcc1-552a-45fa-b94e-d973906490cc")
                },
                new CourseAssignment
                {
                    CourseId = new Guid("db564e68-2fe5-42e5-ba48-b2b49034d3d2"),
                    InstructorId = new Guid("2a12c3f2-fc7a-4bd2-9f66-21a9c79d1893")
                },
                new CourseAssignment
                {
                    CourseId = new Guid("83af998c-0bfd-4855-8c5a-4e1920b9d025"),
                    InstructorId = new Guid("63b92923-68a5-4053-9bf7-5e41c4fe1d91")
                },
                new CourseAssignment
                {
                    CourseId = new Guid("597800e1-0267-4ba0-81dd-a0f07aa98b20"),
                    InstructorId = new Guid("5b225eaa-ca3e-461d-85be-fb4608f87148")
                },
                new CourseAssignment
                {
                    CourseId = new Guid("b178e749-1f02-4461-8e5d-bb97c49eb375"),
                    InstructorId = new Guid("5b225eaa-ca3e-461d-85be-fb4608f87148")
                }
            );
        }
    }
}
