using Microsoft.EntityFrameworkCore;
using SimpleVoc.Domain.Entities;

namespace SimpleVoc.Infrastructure.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Vocabulary> Vocabularies { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
    }
}
