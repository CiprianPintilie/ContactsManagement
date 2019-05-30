using System.Threading.Tasks;
using BusinessLayer.Models;

namespace BusinessLayer.Interop
{
    public interface ICompanyService
    {
        Task<CompanyModel> GetByIdAsync(int id);
        Task<CompanyModel[]> GetByIdsAsync(int[] ids);
        Task<CompanyModel> CreateAsync(CompanyModel company);
        Task UpdateAsync(int id, CompanyModel company);
        Task<bool> CompanyDataConflictsAsync(string name, string vat);
    }
}
