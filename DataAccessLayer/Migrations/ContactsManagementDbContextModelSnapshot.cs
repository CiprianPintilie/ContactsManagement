﻿// <auto-generated />
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(ContactsManagementDbContext))]
    partial class ContactsManagementDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataAccessLayer.Entities.CompanyAddressEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City");

                    b.Property<int>("CompanyId");

                    b.Property<string>("Country");

                    b.Property<int>("PostCode");

                    b.Property<string>("Street");

                    b.Property<int>("StreetNumber");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("CompanyAddress");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.CompanyEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MainCity")
                        .IsRequired();

                    b.Property<string>("MainCountry")
                        .IsRequired();

                    b.Property<int>("MainPostCode");

                    b.Property<string>("MainStreet")
                        .IsRequired();

                    b.Property<int>("MainStreetNumber");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Vat")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("Vat")
                        .IsUnique();

                    b.ToTable("Company");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.ContactCompanyEntity", b =>
                {
                    b.Property<int>("CompanyId");

                    b.Property<int>("ContactId");

                    b.HasKey("CompanyId", "ContactId");

                    b.HasIndex("ContactId");

                    b.ToTable("ContactCompany");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.ContactEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("EmailAddress")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("PostCode");

                    b.Property<string>("Street");

                    b.Property<int>("StreetNumber");

                    b.Property<string>("Type")
                        .IsRequired();

                    b.Property<string>("Vat");

                    b.HasKey("Id");

                    b.HasIndex("EmailAddress")
                        .IsUnique();

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.CompanyAddressEntity", b =>
                {
                    b.HasOne("DataAccessLayer.Entities.CompanyEntity", "Company")
                        .WithMany("Addresses")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataAccessLayer.Entities.ContactCompanyEntity", b =>
                {
                    b.HasOne("DataAccessLayer.Entities.CompanyEntity", "Company")
                        .WithMany("ContactCompanies")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataAccessLayer.Entities.ContactEntity", "Contact")
                        .WithMany("ContactCompanies")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
