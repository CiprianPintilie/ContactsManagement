using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Interop
{
    public interface IContactQuery
    {
        Task<ContactEntity> GetByEmailAddressAsync(string emailAddress);
    }
}
