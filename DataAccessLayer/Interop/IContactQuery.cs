using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Interop
{
    public interface IContactQuery
    {
        Task<ContactEntity> GetByIdAsync(int id);
        Task<ContactEntity> GetByEmailAddressAsync(string emailAddress);
    }
}
