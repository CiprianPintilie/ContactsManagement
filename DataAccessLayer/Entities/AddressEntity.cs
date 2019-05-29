using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    public class AddressEntity
    {
        public int Id { get; set; }
        public bool MainAddress { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int PostCode { get; set; }
        public string Street { get; set; }
        public int StreetNumber { get; set; }

        public ContactEntity Contact { get; set; }
        public ICollection<CompanyAddressEntity> CompanyAddresses { get; set; }
    }
}
