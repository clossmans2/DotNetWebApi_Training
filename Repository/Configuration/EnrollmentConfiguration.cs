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
    public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.HasData(
                new Enrollment
                {
                    Id = Guid.NewGuid(),
                    CourseId = new Guid("ba22eae4-8282-483d-8d43-e3b47bd105d4"),
                    StudentId = new Guid("06917677-cdd6-4523-91b8-88d6d0a912d2"),
                    Grade = Grade.A
                },
                new Enrollment
                {
                    Id = Guid.NewGuid(),
                    StudentId = new Guid("06917677-cdd6-4523-91b8-88d6d0a912d2"),
                    CourseId = new Guid("854f1892-e043-49e0-9573-5544e833a8d3"),
                    Grade = Grade.C
                },
                new Enrollment
                {
                    Id = Guid.NewGuid(),
                    StudentId = new Guid("06917677-cdd6-4523-91b8-88d6d0a912d2"),
                    CourseId = new Guid("ad18dff5-58ee-4e02-ba83-ffd1c8a1f56e"),
                    Grade = Grade.B
                },
                new Enrollment
                {
                    Id = Guid.NewGuid(),
                    StudentId = new Guid("798acf1b-7339-44bd-8367-7132a978d7b1"),
                    CourseId = new Guid("db564e68-2fe5-42e5-ba48-b2b49034d3d2"),
                    Grade = Grade.B
                },
                new Enrollment
                {
                    Id = Guid.NewGuid(),
                    StudentId = new Guid("798acf1b-7339-44bd-8367-7132a978d7b1"),
                    CourseId = new Guid("83af998c-0bfd-4855-8c5a-4e1920b9d025"),
                    Grade = Grade.B
                },
                new Enrollment
                {
                    Id = Guid.NewGuid(),
                    StudentId = new Guid("798acf1b-7339-44bd-8367-7132a978d7b1"),
                    CourseId = new Guid("597800e1-0267-4ba0-81dd-a0f07aa98b20"),
                    Grade = Grade.B
                },
                new Enrollment
                {
                    Id = Guid.NewGuid(),
                    StudentId = new Guid("2a36409f-6732-459b-b7d1-a561c521a3cb"),
                    CourseId = new Guid("ba22eae4-8282-483d-8d43-e3b47bd105d4"),
                },
                new Enrollment
                {
                    Id = Guid.NewGuid(),
                    StudentId = new Guid("2a36409f-6732-459b-b7d1-a561c521a3cb"),
                    CourseId = new Guid("854f1892-e043-49e0-9573-5544e833a8d3"),
                    Grade = Grade.B
                },
                new Enrollment
                {
                    Id = Guid.NewGuid(),
                    StudentId = new Guid("7d84360e-4967-4c7b-8e4c-0f085de7ca4d"),
                    CourseId = new Guid("ba22eae4-8282-483d-8d43-e3b47bd105d4"),
                    Grade = Grade.B
                },
                new Enrollment
                {
                    Id = Guid.NewGuid(),
                    StudentId = new Guid("7a1be69a-38ac-4cde-a105-615de38c2d12"),
                    CourseId = new Guid("597800e1-0267-4ba0-81dd-a0f07aa98b20"),
                    Grade = Grade.B
                },
                new Enrollment
                {
                    Id = Guid.NewGuid(),
                    StudentId = new Guid("5e9c10d4-3b0a-4ccb-8a77-fb2d7e702c6b"),
                    CourseId = new Guid("b178e749-1f02-4461-8e5d-bb97c49eb375"),
                    Grade = Grade.B
                }
                );
        }
    }
}
