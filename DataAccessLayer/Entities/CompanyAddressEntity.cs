using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
    [Table("CompanyAddress")]
    public class CompanyAddressEntity
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int PostCode { get; set; }
        public string Street { get; set; }
        public int StreetNumber { get; set; }

        public int CompanyId { get; set; }
        public CompanyEntity Company { get; set; }
    }
}
