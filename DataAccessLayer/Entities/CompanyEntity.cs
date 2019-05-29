using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class CompanyEntity
    {
        public string Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
