using System.Threading.Tasks;
using BusinessLayer.Interop;
using BusinessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactsManagement.Controllers
{
    [Route("api/[controller]")]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CompanyModel), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        public async Task<IActionResult> Create([FromBody]CompanyModel company)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var companyConflicts = await _companyService.CompanyDataConflictsAsync(company.Name, company.Vat);

            if (companyConflicts)
                return Conflict($"The name '{company.Name}' or the VAT number '{company.Vat}' is already used by another company");

            var createdCompany = await _companyService.CreateAsync(company);

            return Created($"/companies/{createdCompany.Id}", createdCompany);
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(int id, [FromBody]CompanyModel company)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var companyExists = await _companyService.GetByIdAsync(id);

            if (companyExists is null)
                return NotFound($"No company with the id '{id}' was found");

            var companyConflicts = await _companyService.CompanyDataConflictsAsync(company.Name, company.Vat);

            if (companyConflicts)
                return Conflict($"The name '{company.Name}' or the VAT number '{company.Vat}' is already used by another company");

            await _companyService.UpdateAsync(id, company);

            return Ok();
        }
    }
}
