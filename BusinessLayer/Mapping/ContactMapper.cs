using BusinessLayer.Models;
using DataAccessLayer.Entities;

namespace BusinessLayer.Mapping
{
    public static class ContactMapper
    {
        public static ContactEntity ToEntity(this ContactModel contact)
        {
            return new ContactEntity
            {
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Type = contact.Type,
                Vat = contact.Vat,
                Address = new AddressEntity
                {
                    MainAddress = true,
                    Id = contact.Address.Id,
                    City = contact.Address.City,
                    Country = contact.Address.Country,
                    PostCode = contact.Address.PostCode,
                    Street = contact.Address.Street,
                    StreetNumber = contact.Address.StreetNumber
                }
            };
        }

        public static ContactModel ToModel(this ContactEntity contactEntity)
        {
            return new ContactModel
            {
                Id = contactEntity.Id,
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
