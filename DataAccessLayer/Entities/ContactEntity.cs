using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class ContactEntity
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        public string Type { get; set; }
        public string Vat { get; set; }

        public int AddressId { get; set; }
        public AddressEntity Address { get; set; }

        public ICollection<ContactCompanyEntity> ContactCompanies { get; set; }
    }
}
