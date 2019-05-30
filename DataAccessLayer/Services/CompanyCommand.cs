using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using DataAccessLayer.Interop;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Services
{
    public class CompanyCommand : ICompanyCommand
    {
        private readonly ContactsManagementDbContext _context;

        public CompanyCommand(ContactsManagementDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(CompanyEntity company)
        {
            await _context.AddAsync(company);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int companyId, CompanyEntity company)
        {
            var companyEntity = await _context.Company.FindAsync(companyId);

            var companyAddresses = await _context.CompanyAddress
                .Where(address => address.CompanyId.Equals(companyId))
                .ToListAsync();

            UpdateProperties(companyEntity, company);

            _context.CompanyAddress.RemoveRange(companyAddresses);
            _context.Company.Update(companyEntity);

            await _context.SaveChangesAsync();
        }

        private void UpdateProperties(CompanyEntity companyEntity, CompanyEntity company)
        {
            companyEntity.Name = company.Name;
            companyEntity.Vat = company.Vat;
            companyEntity.MainCountry = company.MainCountry;
            companyEntity.MainCity = company.MainCity;
            companyEntity.MainPostCode = company.MainPostCode;
            companyEntity.MainStreet = company.MainStreet;
            companyEntity.MainStreetNumber = company.MainStreetNumber;
            companyEntity.Addresses = company.Addresses;
        }
    }
}
