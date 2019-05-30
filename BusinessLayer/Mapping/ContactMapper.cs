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
                StreetNumber = contactModel.StreetNumber
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
                City = contactEntity.City,
                Country = contactEntity.Country,
                PostCode = contactEntity.PostCode,
                Street = contactEntity.Street,
                StreetNumber = contactEntity.StreetNumber
            };
        }
    }
}
