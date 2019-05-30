using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interop;
using BusinessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactsManagement.Controllers
{
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly ICompanyService _companyService;

        public ContactsController(
            IContactService contactService,
            ICompanyService companyService)
        {
            _contactService = contactService;
            _companyService = companyService;
        }

        /// <summary>
        /// Gets a contact by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var contact = await _contactService.GetByIdAsync(id);
            return Ok(contact);
        }

        /// <summary>
        /// Creates a new contact
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ContactModel), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        public async Task<IActionResult> Create([FromBody]ContactModel contact)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (! _contactService.ContactDataIsValidRegardingType(contact))
                return BadRequest("The contact must have a VAT number only if its type is freelance");

            var contactExists = await _contactService.GetByEmailAddressAsync(contact.EmailAddress);

            if (!(contactExists is null))
                return Conflict($"A contact with the email address '{contact.EmailAddress}' already exist");

            if (contact.Companies.Any())
            {
                var existingRelatedCompanies = await _companyService.GetByIdsAsync(contact.Companies.Select(i => i.Id).ToArray());
                if (existingRelatedCompanies.Length != contact.Companies.Length)
                    return NotFound("One or several of the provided companies does not exist");
            }
            
            var createdContact = await _contactService.CreateAsync(contact);

            return Created($"/contacts/{createdContact.Id}", createdContact);
        }

        /// <summary>
        /// Updates an existing contact
        /// </summary>
        /// <param name="contact"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update([FromBody]ContactModel contact, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_contactService.ContactDataIsValidRegardingType(contact))
                return BadRequest("The contact must have a VAT number only if its type is freelance");

            var contactExists = await _contactService.GetByIdAsync(id);

            if (contactExists is null)
                return NotFound($"No contact with the id '{id}' was found");

            var contactWithSameEmailExists = await _contactService.GetByEmailAddressAsync(contact.EmailAddress);

            if (!(contactWithSameEmailExists is null) && contactWithSameEmailExists.Id != id)
                return Conflict($"A contact with the email address '{contact.EmailAddress}' already exist");

            if (contact.Companies.Any())
            {
                var existingRelatedCompanies = await _companyService.GetByIdsAsync(contact.Companies.Select(i => i.Id).ToArray());
                if (existingRelatedCompanies.Length != contact.Companies.Length)
                    return NotFound("One or several of the provided companies does not exist");
            }

            await _contactService.UpdateAsync(id, contact);

            return Ok();
        }

        /// <summary>
        /// Deletes a contact
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            await _contactService.DeleteAsync(id);
            return NoContent();
        }
    }
}
