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
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasData(
                    new Instructor
                    {
                        Id = new Guid("5b225eaa-ca3e-461d-85be-fb4608f87148"),
                        FirstMidName = "Kim",
                        LastName = "Abercrombie",
                        Email = "kabercrombie@contosouniversity.edu",
                        HireDate = DateTime.Parse("1995-03-11")
                    },
                    new Instructor
                    {
                        Id = new Guid("2a12c3f2-fc7a-4bd2-9f66-21a9c79d1893"),
                        FirstMidName = "Fadi",
                        LastName = "Fakhouri",
                        Email = "ffakhouri@contosouniveristy.edu",
                        HireDate = DateTime.Parse("2002-07-06")
                    },
                    new Instructor
                    {
                        Id = new Guid("63b92923-68a5-4053-9bf7-5e41c4fe1d91"),
                        FirstMidName = "Roger",
                        LastName = "Harui",
                        Email = "rharui@contosouniversity.edu",
                        HireDate = DateTime.Parse("1998-07-01")
                    },
                    new Instructor
                    {
                        Id = new Guid("e24a644d-9a45-4f66-966c-580fd191573a"),
                        FirstMidName = "Candace",
                        LastName = "Kapoor",
                        Email = "ckapoor@contosouniversity.edu",
                        HireDate = DateTime.Parse("2001-01-15")
                    },
                    new Instructor
                    {
                        Id = new Guid("455dfcc1-552a-45fa-b94e-d973906490cc"),
                        FirstMidName = "Roger",
                        LastName = "Zheng",
                        Email = "rzheng@contosouniversity.edu",
                        HireDate = DateTime.Parse("2004-02-12")
                    }
                );
        }
    }
}
