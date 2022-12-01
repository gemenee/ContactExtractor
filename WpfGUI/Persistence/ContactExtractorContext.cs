using Microsoft.EntityFrameworkCore;
using PersonContactExtractor.Persistance.Entities;

namespace PersonContactExtractor.Persistance
{
    public class ContactExtractorContext : DbContext
    {
        public ContactExtractorContext(DbContextOptions<ContactExtractorContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<DocumentEntity> Documents { get; set; }
        public DbSet<ResultEntity> Results { get; set; }
        public DbSet<PersonContacts> Persons { get; set; }
        public DbSet<Organization> Organizations { get; set; }
    }
}