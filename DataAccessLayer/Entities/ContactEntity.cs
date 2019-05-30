using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class ContactEntity
    {
        public int Id { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        public string Type { get; set; }
        public string Vat { get; set; }

        public string Country { get; set; }
        public string City { get; set; }
        public int PostCode { get; set; }
        public string Street { get; set; }
        public int StreetNumber { get; set; }

        public ICollection<ContactCompanyEntity> ContactCompanies { get; set; }
    }
}
