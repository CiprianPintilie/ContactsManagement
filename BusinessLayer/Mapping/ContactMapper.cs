using System;
using System.Linq;
using BusinessLayer.Models;
using DataAccessLayer.Entities;

namespace BusinessLayer.Mapping
{
    public static class ContactMapper
    {
        public static ContactEntity ToEntity(this ContactModel contactModel)
        {
            return new ContactEntity
            {
                EmailAddress = contactModel.EmailAddress,
                FirstName = contactModel.FirstName,
                LastName = contactModel.LastName,
                Type = contactModel.Type,
                Vat = contactModel.Vat,
                City = contactModel.City,
                Country = contactModel.Country,
                PostCode = contactModel.PostCode,
                Street = contactModel.Street,
                StreetNumber = contactModel.StreetNumber,
                ContactCompanies = contactModel.Companies.Select(company => new ContactCompanyEntity
                {
                    CompanyId = company.Id
                }).ToList()
            };
        }

        public static ContactModel ToModel(this ContactEntity contactEntity)
        {
            try
            {
                return new ContactModel
                {
                    Id = contactEntity.Id,
                    EmailAddress = contactEntity.EmailAddress,
                    FirstName = contactEntity.FirstName,
                    LastName = contactEntity.LastName,
                    Type = contactEntity.Type,
                    Vat = contactEntity.Vat,
                    City = contactEntity.City,
                    Country = contactEntity.Country,
                    PostCode = contactEntity.PostCode,
                    Street = contactEntity.Street,
                    StreetNumber = contactEntity.StreetNumber,
                    Companies = contactEntity.ContactCompanies.Select(company => new CompanyModel
                    {
                        Id = company.CompanyId,
                        Name = company.Company?.Name,
                        Vat = company.Company?.Vat,
                        MainCountry = company.Company?.MainCountry,
                        MainCity = company.Company?.MainCity,
                        MainPostCode = company.Company?.MainPostCode ?? 0,
                        MainStreet = company.Company?.MainStreet,
                        MainStreetNumber = company.Company?.MainStreetNumber ?? 0,
                        CompanyAddresses = company.Company?.Addresses?
                            .Select(address => address.ToModel())
                            .ToArray()
                    }).ToArray()
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
    }
}
