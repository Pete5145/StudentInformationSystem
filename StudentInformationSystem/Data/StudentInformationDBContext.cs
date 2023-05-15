using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.Models;

namespace StudentInformationSystem.Data
{
    public class StudentInformationDBContext: DbContext
    {
        public StudentInformationDBContext(DbContextOptions options): base(options)
        {
            
        }

        public DbSet<Student> Students { get; set; } 
        public DbSet<Course> Courses { get; set; } 
        public DbSet<Enrollment> Enrollments { get; set; } 
    }
}
