using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using DataAccessLayer.Interop;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Services
{
    public class ContactQuery : IContactQuery
    {
        private readonly ContactsManagementDbContext _context;

        public ContactQuery(ContactsManagementDbContext context)
        {
            _context = context;
        }

        public async Task<ContactEntity> GetByEmailAddressAsync(string emailAddress)
        {
            var contact = await _context.Contact
                .Where(c => c.EmailAddress.Equals(emailAddress))
                .SingleOrDefaultAsync();

            return contact;
        }
    }
}
