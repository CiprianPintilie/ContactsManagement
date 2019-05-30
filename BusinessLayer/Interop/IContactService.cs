using System.Threading.Tasks;
using BusinessLayer.Models;

namespace BusinessLayer.Interop
{
    public interface IContactService
    {
        Task<ContactModel> GetByIdAsync(int id);
        Task<ContactModel> GetByEmailAddressAsync(string emailAddress);
        Task<ContactModel> CreateAsync(ContactModel contact);
        Task UpdateAsync(int id, ContactModel contact);
    }
}
