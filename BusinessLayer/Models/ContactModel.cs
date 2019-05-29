namespace BusinessLayer.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Type { get; set; }
        public string Vat { get; set; }
        public AddressModel Address { get; set; }
    }
}
