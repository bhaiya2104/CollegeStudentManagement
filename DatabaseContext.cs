using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CollegeStudentManagement.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {
        }

        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Login>Logins { get; set; }= null!; 
    }
}