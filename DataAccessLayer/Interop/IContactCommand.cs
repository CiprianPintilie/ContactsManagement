using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Interop
{
    public interface IContactCommand
    {
        Task CreateAsync(ContactEntity contact);
        Task UpdateAsync(int contactId, ContactEntity contact);
    }
}
