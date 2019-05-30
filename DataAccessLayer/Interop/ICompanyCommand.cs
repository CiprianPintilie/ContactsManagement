using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Interop
{
    public interface ICompanyCommand
    {
        Task CreateAsync(CompanyEntity company);
        Task UpdateAsync(int companyId, CompanyEntity company);
    }
}
