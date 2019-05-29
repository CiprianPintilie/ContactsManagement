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

        public ContactService(IContactCommand contactCommand)
        {
            _contactCommand = contactCommand;
        }

        public async Task<ContactModel> CreateAsync(ContactModel contact)
        {
            var contactEntity = contact.ToEntity();
            await _contactCommand.CreateAsync(contactEntity);
            return contactEntity.ToModel();
        }
    }
}
