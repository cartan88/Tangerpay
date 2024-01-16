using Tangerpay.Api.Services;
using Tangerpay.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Tangerpay.Api.Controllers
{

    [ApiController]
    public class ContactsController(IContactsService contactsService) : ControllerBase
    {
        private readonly IContactsService contactsService = contactsService;

        [HttpPost]
        [Route("recordContactDetails")]
        [ProducesResponseType(200)]
        public IActionResult CreateClient([FromBody] Contact contact)
        {
            var contactId = contactsService.CreateContact(contact);
            return Ok(contactId);
        }

        [HttpGet]
        [Route("retrieveContactDetails")]
        [ProducesResponseType(200)]
        public IActionResult GetClientsByName([FromQuery] int id)
        {
            var contact = contactsService.GetContact(id);
            return Ok(contact);
        }
    }
}
