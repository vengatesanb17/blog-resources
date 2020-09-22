using Microsoft.EntityFrameworkCore;
using StudentManagement.Data.Models;

namespace StudentManagement.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }
        
        public DbSet<Student> Students { get; set; }
    }
}
