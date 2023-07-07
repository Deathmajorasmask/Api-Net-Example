using Microsoft.EntityFrameworkCore;
using UniversityWebApiBackend.Models.DataModels;

namespace UniversityWebApiBackend.DataAccess
{
    public class UniversityDBContext: DbContext
    {
        public UniversityDBContext(DbContextOptions<UniversityDBContext> options): base(options)
        {

        }

        // TODO Add DBSets (Tables of DB)
        public DbSet<Users>? Users { get; set; } // Table Users
        public DbSet<Course>? Courses { get; set; } // Table Courses
        public DbSet<IndexClass>? IndexClasses { get; set; } // Table IndexClasses
        public DbSet<Category>? Categories { get; set; } // Table Categories
        public DbSet<Student>? Students { get; set; } // Table Students

    }
}
