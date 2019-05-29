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
                Address = new AddressEntity
                {
                    MainAddress = true,
                    Id = contactModel.Address.Id,
                    City = contactModel.Address.City,
                    Country = contactModel.Address.Country,
                    PostCode = contactModel.Address.PostCode,
                    Street = contactModel.Address.Street,
                    StreetNumber = contactModel.Address.StreetNumber
                }
            };
        }

        public static ContactModel ToModel(this ContactEntity contactEntity)
        {
            return new ContactModel
            {
                Id = contactEntity.Id,
                EmailAddress = contactEntity.EmailAddress,
                FirstName = contactEntity.FirstName,
                LastName = contactEntity.LastName,
                Type = contactEntity.Type,
                Vat = contactEntity.Vat,
                Address = new AddressModel
                {
                    MainAddress = true,
                    Id = contactEntity.Address.Id,
                    City = contactEntity.Address.City,
                    Country = contactEntity.Address.Country,
                    PostCode = contactEntity.Address.PostCode,
                    Street = contactEntity.Address.Street,
                    StreetNumber = contactEntity.Address.StreetNumber
                }
            };
        }
    }
}
