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

        public async Task<ContactModel> GetByIdAsync(int id)
        {
            var contactEntity = await _contactQuery.GetByIdAsync(id);
            return contactEntity?.ToModel();
        }
        
        public async Task<ContactModel> CreateAsync(ContactModel contact)
        {
            var contactEntity = contact.ToEntity();
            await _contactCommand.CreateAsync(contactEntity);
            return contactEntity.ToModel();
        }

        public async Task UpdateAsync(int id, ContactModel contact)
        {
            await _contactCommand.UpdateAsync(id, contact.ToEntity());
        }

        public async Task DeleteAsync(int id)
        {
            await _contactCommand.DeleteAsync(id);
        }

        public async Task<ContactModel> GetByEmailAddressAsync(string emailAddress)
        {
            var contactEntity = await _contactQuery.GetByEmailAddressAsync(emailAddress);
            return contactEntity?.ToModel();
        }

        public bool ContactDataIsValidRegardingType(ContactModel contact)
        {
            if (contact.Type.Equals(ContactType.EMPLOYEE) && !string.IsNullOrEmpty(contact.Vat))
                return false;
            if (contact.Type.Equals(ContactType.FREELANCE) && string.IsNullOrEmpty(contact.Vat))
                return false;

            return true;
        }
    }
}
