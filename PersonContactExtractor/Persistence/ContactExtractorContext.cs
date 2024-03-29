﻿using Microsoft.EntityFrameworkCore;

namespace PersonContactExtractor.Persistance
{
    public class ContactExtractorContext : DbContext
    {
        public ContactExtractorContext(DbContextOptions<ContactExtractorContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<DocumentEntity> Documents { get; set; }
        public DbSet<ResultEntity> Results { get; set; }
        public DbSet<PersonContacts> Persons { get; set; }
        public DbSet<OrganizationEntity> Organizations { get; set; }
    }
}