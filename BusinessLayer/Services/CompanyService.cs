using System.Threading.Tasks;
using BusinessLayer.Interop;
using BusinessLayer.Mapping;
using BusinessLayer.Models;
using DataAccessLayer.Interop;

namespace BusinessLayer.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyCommand _companyCommand;
        private readonly ICompanyQuery _companyQuery;

        public CompanyService(
            ICompanyCommand companyCommand,
            ICompanyQuery companyQuery)
        {
            _companyCommand = companyCommand;
            _companyQuery = companyQuery;
        }

        public async Task<CompanyModel> GetByIdAsync(int id)
        {
            var company = await _companyQuery.GetByIdAsync(id);

            return company?.ToModel();
        }

        public async Task<CompanyModel> CreateAsync(CompanyModel company)
        {
            var companyEntity = company.ToEntity();
            await _companyCommand.CreateAsync(companyEntity);

            return companyEntity.ToModel();
        }
        
        public async Task UpdateAsync(int id, CompanyModel company)
        {
            await _companyCommand.UpdateAsync(id, company.ToEntity());
        }

        public async Task<bool> CompanyDataConflictsAsync(string name, string vat)
        {
            var companySearchedByName = await _companyQuery.GetByNameAsync(name);
            var companySearchedByVat = await _companyQuery.GetByVatAsync(vat);

            return !(companySearchedByName is null) || !(companySearchedByVat is null);
        }
    }
}
