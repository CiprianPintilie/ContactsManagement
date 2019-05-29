using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
    [Table("ContactCompany")]
    public class ContactCompanyEntity
    {
        public int ContactId { get; set; }
        public ContactEntity Contact { get; set; }

        public int CompanyId { get; set; }
        public CompanyEntity Company { get; set; }
    }
}
