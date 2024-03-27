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
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasData(
                new Course
                {
                    Id = new Guid("ba22eae4-8282-483d-8d43-e3b47bd105d4"),
                    Title = "Chemistry",
                    Credits = 3,
                    DepartmentId = new Guid("ce1815fb-6730-4b7a-9e3c-322db0c98414"),
                },
                new Course
                {
                    Id = new Guid("854f1892-e043-49e0-9573-5544e833a8d3"),
                    Title = "Microeconomics",
                    Credits = 3,
                    DepartmentId = new Guid("00c4512a-6c05-482b-9026-3f413f477132"),
                },
                new Course
                {
                    Id = new Guid("ad18dff5-58ee-4e02-ba83-ffd1c8a1f56e"),
                    Title = "Macroeconomics",
                    Credits = 3,
                    DepartmentId = new Guid("00c4512a-6c05-482b-9026-3f413f477132"),
                },
                new Course
                {
                    Id = new Guid("db564e68-2fe5-42e5-ba48-b2b49034d3d2"),
                    Title = "Calculus",
                    Credits = 4,
                    DepartmentId = new Guid("c8eee19f-7040-492f-81c8-62cbe50d8467")
                },
                new Course
                {
                    Id = new Guid("83af998c-0bfd-4855-8c5a-4e1920b9d025"),
                    Title = "Trigonometry",
                    Credits = 4,
                    DepartmentId = new Guid("c8eee19f-7040-492f-81c8-62cbe50d8467")
                },
                new Course
                {
                    Id = new Guid("597800e1-0267-4ba0-81dd-a0f07aa98b20"),
                    Title = "Composition",
                    Credits = 3,
                    DepartmentId = new Guid("c19f20e6-e77d-492d-bbc2-dce3c7603448")
                },
                new Course
                {
                    Id = new Guid("b178e749-1f02-4461-8e5d-bb97c49eb375"),
                    Title = "Literature",
                    Credits = 4,
                    DepartmentId = new Guid("c19f20e6-e77d-492d-bbc2-dce3c7603448")
                }
            );
        }
    }
}
