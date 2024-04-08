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
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasData(
                new Department
                {
                    Id = new Guid("c19f20e6-e77d-492d-bbc2-dce3c7603448"),
                    Name = "English",
                    Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorId = new Guid("5b225eaa-ca3e-461d-85be-fb4608f87148")
                },
                new Department
                {
                    Id = new Guid("c8eee19f-7040-492f-81c8-62cbe50d8467"),
                    Name = "Mathematics",
                    Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorId = new Guid("2a12c3f2-fc7a-4bd2-9f66-21a9c79d1893")
                },
                new Department
                {
                    Id = new Guid("ce1815fb-6730-4b7a-9e3c-322db0c98414"),
                    Name = "Engineering",
                    Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorId = new Guid("63b92923-68a5-4053-9bf7-5e41c4fe1d91")
                },
                new Department
                {
                    Id = new Guid("00c4512a-6c05-482b-9026-3f413f477132"),
                    Name = "Economics",
                    Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorId = new Guid("e24a644d-9a45-4f66-966c-580fd191573a")
                }
            );
        }
    }
}
