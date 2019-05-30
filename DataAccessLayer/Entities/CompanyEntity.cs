using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class CompanyEntity
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public string Vat { get; set; }

        public string MainCountry { get; set; }
        public string MainCity { get; set; }
        public int MainPostCode { get; set; }
        public string MainStreet { get; set; }
        public int MainStreetNumber { get; set; }

        public ICollection<ContactCompanyEntity> ContactCompanies { get; set; }
        public ICollection<CompanyAddressEntity> CompanyAddresses { get; set; }
    }
}
