using System.Linq;
using BusinessLayer.Models;
using DataAccessLayer.Entities;

namespace BusinessLayer.Mapping
{
    public static class CompanyMapper
    {
        public static CompanyEntity ToEntity(this CompanyModel companyModel)
        {
            return new CompanyEntity
            {
                Name = companyModel.Name,
                Vat = companyModel.Vat,
                MainCountry = companyModel.MainCountry,
                MainCity = companyModel.MainCity,
                MainPostCode = companyModel.MainPostCode,
                MainStreet = companyModel.MainStreet,
                MainStreetNumber = companyModel.MainStreetNumber,
                Addresses = companyModel.CompanyAddresses.Select(address => new CompanyAddressEntity
                {
                    Country = address.Country,
                    City = address.City,
                    PostCode = address.PostCode,
                    Street = address.Street,
                    StreetNumber = address.StreetNumber
                }).ToList()
            };
        }

        public static CompanyModel ToModel(this CompanyEntity companyEntity)
        {
            var companyModel = new CompanyModel
            {
                Id = companyEntity.Id,
                Name = companyEntity.Name,
                Vat = companyEntity.Vat,
                MainCountry = companyEntity.MainCountry,
                MainCity = companyEntity.MainCity,
                MainPostCode = companyEntity.MainPostCode,
                MainStreet = companyEntity.MainStreet,
                MainStreetNumber = companyEntity.MainStreetNumber,
                CompanyAddresses = companyEntity.Addresses.Select(address => new CompanyAddressModel
                {
                    Id = address.Id,
                    Country = address.Country,
                    City = address.City,
                    PostCode = address.PostCode,
                    Street = address.Street,
                    StreetNumber = address.StreetNumber
                }).ToArray()
            };

            return companyModel;
        }
    }
}
