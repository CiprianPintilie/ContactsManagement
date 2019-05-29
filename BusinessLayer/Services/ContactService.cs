using System.Threading.Tasks;
using BusinessLayer.Interop;
using BusinessLayer.Mapping;
using BusinessLayer.Models;
using DataAccessLayer.Interop;

namespace BusinessLayer.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactCommand _contactCommand;
        private readonly IContactQuery _contactQuery;

        public ContactService(
            IContactCommand contactCommand,
            IContactQuery contactQuery)
        {
            _contactCommand = contactCommand;
            _contactQuery = contactQuery;
        }

        public async Task<ContactModel> CreateAsync(ContactModel contact)
        {
            var contactEntity = contact.ToEntity();
            await _contactCommand.CreateAsync(contactEntity);
            return contactEntity.ToModel();
        }

        public async Task<bool> ContactExistsAsync(ContactModel contact)
        {
            var contactEntity = await _contactQuery.GetByEmailAddressAsync(contact.EmailAddress);

            return !(contactEntity is null);
        }
    }
}
