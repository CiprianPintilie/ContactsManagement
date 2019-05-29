using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Interop
{
    public interface IContactCommand
    {
        Task CreateAsync(ContactEntity contact);
    }
}
