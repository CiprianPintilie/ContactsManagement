using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class ContactsManagementDbContext : DbContext
    {
        public virtual DbSet<CompanyEntity> Company { get; set; }
        public virtual DbSet<ContactEntity> Contact { get; set; }
        public virtual DbSet<ContactCompanyEntity> ContactCompany { get; set; }
        public virtual DbSet<CompanyAddressEntity> CompanyAddress { get; set; }

        public ContactsManagementDbContext()
        {
        }

        public ContactsManagementDbContext(DbContextOptions<ContactsManagementDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyAddressEntity>(entity =>
            {
                entity.HasKey(address => address.Id);
                entity.Property(address => address.Id)
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<CompanyEntity>(entity =>
            {
                entity.HasKey(company => company.Id);
                entity.Property(company => company.Id)
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<CompanyEntity>()
                .HasIndex(company => company.Name)
                .IsUnique();

            modelBuilder.Entity<CompanyEntity>()
                .HasIndex(company => company.Vat)
                .IsUnique();

            modelBuilder.Entity<CompanyEntity>()
                .HasMany(company => company.Addresses)
                .WithOne(companyAddress => companyAddress.Company)
                .HasForeignKey(company => company.CompanyId);

            modelBuilder.Entity<ContactEntity>(entity =>
            {
                entity.HasKey(contact => contact.Id);
                entity.Property(contact => contact.Id)
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ContactEntity>()
                .HasIndex(contact => contact.EmailAddress)
                .IsUnique();

            modelBuilder.Entity<ContactCompanyEntity>()
                .HasKey(contactCompany => new
                {
                    contactCompany.CompanyId,
                    contactCompany.ContactId
                });

            modelBuilder.Entity<ContactCompanyEntity>()
                .HasOne(contactCompany => contactCompany.Company)
                .WithMany(company => company.ContactCompanies)
                .HasForeignKey(contactCompany => contactCompany.CompanyId);

            modelBuilder.Entity<ContactCompanyEntity>()
                .HasOne(contactCompany => contactCompany.Contact)
                .WithMany(contact => contact.ContactCompanies)
                .HasForeignKey(contactCompany => contactCompany.ContactId);
        }
    }
}
