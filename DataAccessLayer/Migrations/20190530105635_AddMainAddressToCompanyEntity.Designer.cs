﻿// <auto-generated />
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(ContactsManagementDbContext))]
    [Migration("20190530105635_AddMainAddressToCompanyEntity")]
    partial class AddMainAddressToCompanyEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataAccessLayer.Entities.AddressEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<int>("PostCode");

                    b.Property<string>("Street");

                    b.Property<int>("StreetNumber");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.CompanyAddressEntity", b =>
                {
                    b.Property<int>("CompanyId");

                    b.Property<int>("AddressId");

                    b.HasKey("CompanyId", "AddressId");

                    b.HasIndex("AddressId");

                    b.ToTable("CompanyAddress");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.CompanyEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MainCity");

                    b.Property<string>("MainCountry");

                    b.Property<int>("MainPostCode");

                    b.Property<string>("MainStreet");

                    b.Property<int>("MainStreetNumber");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<string>("Vat");

                    b.HasKey("Id");

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

                    b.Property<int>("AddressId");

                    b.Property<string>("EmailAddress")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Type")
                        .IsRequired();

                    b.Property<string>("Vat");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.HasIndex("EmailAddress")
                        .IsUnique();

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.CompanyAddressEntity", b =>
                {
                    b.HasOne("DataAccessLayer.Entities.AddressEntity", "Address")
                        .WithMany("CompanyAddresses")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataAccessLayer.Entities.CompanyEntity", "Company")
                        .WithMany("CompanyAddresses")
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

            modelBuilder.Entity("DataAccessLayer.Entities.ContactEntity", b =>
                {
                    b.HasOne("DataAccessLayer.Entities.AddressEntity", "Address")
                        .WithOne("Contact")
                        .HasForeignKey("DataAccessLayer.Entities.ContactEntity", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
