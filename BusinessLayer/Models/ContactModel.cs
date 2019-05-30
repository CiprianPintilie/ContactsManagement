using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", 
            ErrorMessage = "The provided value is not a valid email")]
        public string EmailAddress { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "The provided value must not exceed 50 characters")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "The provided value must not exceed 50 characters")]
        public string LastName { get; set; }
        [Required]
        public string Type { get; set; }
        public string Vat { get; set; }

        public string Country { get; set; }
        public string City { get; set; }
        public int PostCode { get; set; }
        public string Street { get; set; }
        public int StreetNumber { get; set; }
    }
}
