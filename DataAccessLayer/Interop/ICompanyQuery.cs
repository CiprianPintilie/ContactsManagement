using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Interop
{
    public interface ICompanyQuery
    {
        Task<CompanyEntity> GetByIdAsync(int id);
        Task<CompanyEntity> GetByNameAsync(string name);
        Task<CompanyEntity> GetByVatAsync(string vat);
    }
}
