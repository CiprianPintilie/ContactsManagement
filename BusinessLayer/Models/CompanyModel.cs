using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.Models
{
    public class CompanyModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public string Vat { get; set; }
        [Required]
        public string MainCountry { get; set; }
        [Required]
        public string MainCity { get; set; }
        [Required]
        public int MainPostCode { get; set; }
        [Required]
        public string MainStreet { get; set; }
        [Required]
        public int MainStreetNumber { get; set; }
        [Required]

        public CompanyAddressModel[] CompanyAddresses { get; set; }
    }
}