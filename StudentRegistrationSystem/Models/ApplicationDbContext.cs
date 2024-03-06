using System.Collections.Generic;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;

namespace StudentRegistrationSystem.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Registrations> Registrations { get; set; }

        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Courses>().HasData(
                new Courses { CourseID = 1, CourseName = "JAVA", CourseDescription = "Programming Language" },
                new Courses { CourseID = 2, CourseName = "PYTHON", CourseDescription = "Programming Language" },
                new Courses { CourseID = 3, CourseName = "DotNet", CourseDescription = "Programming Language" },
                new Courses { CourseID = 4, CourseName = "SAP", CourseDescription = "Business Module" },
                new Courses { CourseID = 5, CourseName = "DATA SCIENCE", CourseDescription = "Big Data" }
                );
       
        #endregion
        
    }
}
