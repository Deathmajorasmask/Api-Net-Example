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

    }
}
