﻿using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using DataAccessLayer.Interop;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Services
{
    public class CompanyQuery : ICompanyQuery
    {
        private readonly ContactsManagementDbContext _context;

        public CompanyQuery(ContactsManagementDbContext context)
        {
            _context = context;
        }

        public async Task<CompanyEntity> GetCompanyByIdAsync(int id)
        {
            return await _context.Company.FindAsync(id);
        }

        public async Task<CompanyEntity> GetCompanyByNameAsync(string name)
        {
            return await _context.Company
                .Where(c => c.Name.Equals(name))
                .SingleOrDefaultAsync();
        }

        public async Task<CompanyEntity> GetCompanyByVatAsync(string vat)
        {
            return await _context.Company
                .Where(c => c.Vat.Equals(vat))
                .SingleOrDefaultAsync();
        }
    }
}