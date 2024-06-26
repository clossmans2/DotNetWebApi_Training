﻿using Microsoft.EntityFrameworkCore;
using Repository.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Entities.Models;

namespace Repository
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
            
        }

        public DbSet<Student>? Students { get; set; }
        public DbSet<Enrollment>? Enrollments { get; set; }
        public DbSet<Course>? Courses { get; set; }
        public DbSet<Department>? Departments { get; set; }
        public DbSet<Instructor>? Instructors { get; set; }
        public DbSet<CourseAssignment>? CourseAssignments { get; set; }
        public DbSet<OfficeAssignment>? OfficeAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CourseAssignment>()
                .HasKey(c => new { c.CourseId, c.InstructorId });

            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new EnrollmentConfiguration());
            modelBuilder.ApplyConfiguration(new InstructorConfiguration());
            modelBuilder.ApplyConfiguration(new OfficeAssignmentConfiguration());
            modelBuilder.ApplyConfiguration(new CourseAssignmentConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
