using System.Threading.Tasks;
using DataAccessLayer.Entities;
using DataAccessLayer.Interop;

namespace DataAccessLayer.Services
{
    public class ContactCommand : IContactCommand
    {
        private readonly ContactsManagementDbContext _context;

        public ContactCommand(ContactsManagementDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(ContactEntity contact)
        {
            await _context.Contact.AddAsync(contact);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int contactId, ContactEntity contact)
        {
            var contactToUpdate = await _context.Contact.FindAsync(contactId);
            
            UpdateContactProperties(contactToUpdate, contact);
            _context.Contact.Update(contactToUpdate);

            await _context.SaveChangesAsync();
        }

        private void UpdateContactProperties(ContactEntity contactToUpdate, ContactEntity contact)
        {
            contactToUpdate.EmailAddress = contact.EmailAddress;
            contactToUpdate.FirstName = contact.FirstName;
            contactToUpdate.LastName = contact.LastName;
            contactToUpdate.Type = contact.Type;
            contactToUpdate.Vat = contact.Vat;
            contactToUpdate.Country = contact.Country;
            contactToUpdate.City = contact.City;
            contactToUpdate.PostCode = contact.PostCode;
            contactToUpdate.Street = contact.Street;
            contactToUpdate.StreetNumber = contact.StreetNumber;
        }
    }
}
