using AddressBook.Application.Contacts;
using AddressBook.Application.Contacts.DTOs;
using AddressBook.Infrastructure.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace AddressBook.API.Controllers
{
    [ApiController]
    [Route("api/contacts")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet("")]
        public async Task<ActionResult<PaginationResultDto<ContactDto>>> Get([BindRequired, FromQuery]PaginationDto pagination)
        {
            return await _contactService.SearchAsync(pagination);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContactDto>> Get(int id)
        {
            return await _contactService.GetAsync(id);
        }

        [HttpPost("")]
        public async Task Create(ContactDto contact)
        {
            await _contactService.CreateAsync(contact);
        }

        [HttpPut("")]
        public async Task Update(ContactDto contact)
        {
            await _contactService.UpdateAsync(contact);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _contactService.DeleteAsync(id);
        }
    }
}