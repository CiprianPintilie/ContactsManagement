using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class ContactsManagementDbContext : DbContext
    {
        public virtual DbSet<CompanyEntity> Company { get; set; }

        public ContactsManagementDbContext()
        {
        }

        public ContactsManagementDbContext(DbContextOptions<ContactsManagementDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyEntity>(entity =>
            {
                entity.HasKey(company => company.Id);
                entity.Property(company => company.Id)
                    .HasDefaultValueSql("NEWID()");
            });
        }
    }
}
