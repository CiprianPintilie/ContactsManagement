using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Interop
{
    public interface ICompanyQuery
    {
        Task<CompanyEntity> GetCompanyByIdAsync(int id);
        Task<CompanyEntity> GetCompanyByNameAsync(string name);
        Task<CompanyEntity> GetCompanyByVatAsync(string vat);
    }
}
