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

        public async Task<ContactEntity> GetByIdAsync(int id)
        {
            return await _context.Contact
                .Include(i => i.ContactCompanies)
                .ThenInclude(i => i.Company)
                .ThenInclude(i => i.Addresses)
                .Where(i => i.Id.Equals(id))
                .SingleOrDefaultAsync();
        }

        public async Task<ContactEntity> GetByEmailAddressAsync(string emailAddress)
        {
            return await _context.Contact
                .Include(i => i.ContactCompanies)
                .ThenInclude(i => i.Company)
                .ThenInclude(i => i.Addresses)
                .Where(i => i.EmailAddress.Equals(emailAddress))
                .SingleOrDefaultAsync();
        }
    }
}
