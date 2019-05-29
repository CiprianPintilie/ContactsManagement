using System.Threading.Tasks;
using BusinessLayer.Models;

namespace BusinessLayer.Interop
{
    public interface IContactService
    {
        Task<ContactModel> CreateAsync(ContactModel contact);
        Task<bool> ContactExistsAsync(ContactModel contact);
    }
}
