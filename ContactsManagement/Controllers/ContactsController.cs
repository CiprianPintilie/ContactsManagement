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

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ContactModel), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        public async Task<IActionResult> Create([FromBody]ContactModel contact)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var contactExists = await _contactService.ContactExistsAsync(contact);

            if (contactExists)
                return Conflict($"A contact with the email address '{contact.EmailAddress}' already exist");

            var createdContact = await _contactService.CreateAsync(contact);

            return Created($"/contacts/{createdContact.Id}", createdContact);
        }
    }
}
