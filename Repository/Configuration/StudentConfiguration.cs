using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repository.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasData(
                    new Student
                    {
                        Id = new Guid("06917677-cdd6-4523-91b8-88d6d0a912d2"),
                        FirstMidName = "Carson",
                        LastName = "Alexander",
                        Email = "calexander@contosouniversity.edu",
                        EnrollmentDate = DateTime.Parse("2010-09-01")
                    },
                    new Student
                    {
                        Id = new Guid("798acf1b-7339-44bd-8367-7132a978d7b1"),
                        FirstMidName = "Meredith",
                        LastName = "Alonso",
                        Email = "malonso@contosouniversity.edu",
                        EnrollmentDate = DateTime.Parse("2012-09-01")
                    },
                    new Student
                    {
                        Id = new Guid("2a36409f-6732-459b-b7d1-a561c521a3cb"),
                        FirstMidName = "Arturo",
                        LastName = "Anand",
                        Email = "aanand@contosouniversity.edu",
                        EnrollmentDate = DateTime.Parse("2013-09-01")
                    },
                    new Student
                    {
                        Id = new Guid("7d84360e-4967-4c7b-8e4c-0f085de7ca4d"),
                        FirstMidName = "Gytis",
                        LastName = "Barzdukas",
                        Email = "gbarzdukas@contosouniversity.edu",
                        EnrollmentDate = DateTime.Parse("2012-09-01")
                    },
                    new Student
                    {
                        Id = new Guid("7a1be69a-38ac-4cde-a105-615de38c2d12"),
                        FirstMidName = "Yan",
                        LastName = "Li",
                        Email = "yli@contosouniversity.edu",
                        EnrollmentDate = DateTime.Parse("2012-09-01")
                    },
                    new Student
                    {
                        Id = new Guid("5e9c10d4-3b0a-4ccb-8a77-fb2d7e702c6b"),
                        FirstMidName = "Peggy",
                        LastName = "Justice",
                        Email = "pjustice@contosouniversity.edu",
                        EnrollmentDate = DateTime.Parse("2011-09-01")
                    },
                    new Student
                    {
                        Id = new Guid("53cea385-aa61-4e81-ba7a-38d7ed60ce4f"),
                        FirstMidName = "Laura",
                        LastName = "Norman",
                        Email = "lnorman@contosouniversity.edu",
                        EnrollmentDate = DateTime.Parse("2013-09-01")
                    },
                    new Student
                    {
                        Id = new Guid("554039c7-cba1-4404-9fbe-21918a9190f7"),
                        FirstMidName = "Nino",
                        LastName = "Olivetto",
                        Email = "nolivetto@contosouniversity.edu",
                        EnrollmentDate = DateTime.Parse("2005-09-01")
                    }
             );
        }
    }
}
