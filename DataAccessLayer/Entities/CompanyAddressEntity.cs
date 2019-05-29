using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
    [Table("CompanyAddress")]
    public class CompanyAddressEntity
    {
        public int CompanyId { get; set; }
        public CompanyEntity Company { get; set; }
        public int AddressId { get; set; }
        public AddressEntity Address { get; set; }
    }
}
