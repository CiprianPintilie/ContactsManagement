namespace BusinessLayer.Models
{
    public class AddressModel
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int PostCode { get; set; }
        public string Street { get; set; }
        public int StreetNumber { get; set; }
    }
}
