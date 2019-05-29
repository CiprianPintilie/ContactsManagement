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
    }
}
