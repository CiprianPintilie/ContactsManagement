using BusinessLayer.Models;
using DataAccessLayer.Entities;

namespace BusinessLayer.Mapping
{
    public static class AddressMapper
    {
        public static CompanyAddressEntity ToEntity(this CompanyAddressModel addressModel)
        {
            return new CompanyAddressEntity
            {
                Country = addressModel.Country,
                City = addressModel.City,
                PostCode = addressModel.PostCode,
                Street = addressModel.Street,
                StreetNumber = addressModel.StreetNumber
            };
        }

        public static CompanyAddressModel ToModel(this CompanyAddressEntity addressEntity)
        {
            return new CompanyAddressModel
            {
                Id = addressEntity.Id,
                Country = addressEntity.Country,
                City = addressEntity.City,
                PostCode = addressEntity.PostCode,
                Street = addressEntity.Street,
                StreetNumber = addressEntity.StreetNumber
            };
        }
    }
}
