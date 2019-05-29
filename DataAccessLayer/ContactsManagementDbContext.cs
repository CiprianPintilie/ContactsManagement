using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class ContactsManagementDbContext : DbContext
    {
        public virtual DbSet<AddressEntity> Address { get; set; }
        public virtual DbSet<CompanyEntity> Company { get; set; }
        public virtual DbSet<ContactEntity> Contact { get; set; }

        public ContactsManagementDbContext()
        {
        }

        public ContactsManagementDbContext(DbContextOptions<ContactsManagementDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddressEntity>(entity =>
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

            modelBuilder.Entity<ContactEntity>(entity =>
            {
                entity.HasKey(contact => contact.Id);
                entity.Property(contact => contact.Id)
                    .ValueGeneratedOnAdd();
                entity.HasOne(contact => contact.Address)
                    .WithOne(address => address.Contact);

            });

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

            modelBuilder.Entity<CompanyAddressEntity>()
                .HasKey(companyAddress => new
                {
                    companyAddress.CompanyId,
                    companyAddress.AddressId
                });

            modelBuilder.Entity<CompanyAddressEntity>()
                .HasOne(companyAddress => companyAddress.Company)
                .WithMany(company => company.CompanyAddresses)
                .HasForeignKey(companyAddress => companyAddress.CompanyId);

            modelBuilder.Entity<CompanyAddressEntity>()
                .HasOne(companyAddress => companyAddress.Address)
                .WithMany(address => address.CompanyAddresses)
                .HasForeignKey(companyAddress => companyAddress.AddressId);
        }
    }
}
