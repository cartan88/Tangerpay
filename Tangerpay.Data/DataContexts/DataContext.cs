using Tangerpay.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Tangerpay.Data.DataContexts
{
    public sealed class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            Contacts = Set<Contact>();
        }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Contact>().HasKey(x => x.Id);
        }
    }
}

