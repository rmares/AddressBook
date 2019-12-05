using AddressBook.Application.Contacts.DTOs;
using AddressBook.Core.Contacts;
using AddressBook.Infrastructure.Application;
using AddressBook.Infrastructure.UnitOfWork;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Application.Contacts
{
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IContactManager _contactManager;
        private readonly IContactRepository _contactRepository;

        public ContactService(
            IUnitOfWork unitOfWork,
            IContactManager contactManager,
            IContactRepository contactRepository)
        {
            _unitOfWork = unitOfWork;
            _contactManager = contactManager;
            _contactRepository = contactRepository;
        }

        public async Task<PaginationResultDto<ContactDto>> SearchAsync(PaginationDto pagination)
        {
            var paginationResult = await _contactRepository.SearchAsync(pagination.PageNumber, pagination.PageSize);

            return paginationResult.MapToPaginationResultDto();
        }

        public async Task<ContactDto> GetAsync(int id)
        {
            var contact = await _contactRepository.GetByIdAsync(id);

            return contact.MapToContactDto();
        }

        public async Task CreateAsync(ContactDto contactDto)
        {
            var contact = await _contactManager.CreateAsync(contactDto.Name, contactDto.DateOfBirth, contactDto.Address);
            foreach (var contactPhone in contactDto.Phones)
            {
                contact.AddPhone(contactPhone.PhoneNumber);
            }

            await _contactRepository.InsertAsync(contact);

            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(ContactDto contactDto)
        {
            var contact = await _contactRepository.GetByIdAsync(contactDto.Id);
            contact.SetName(contactDto.Name);
            contact.SetDateOfBirth(contactDto.DateOfBirth);
            contact.SetAddress(contactDto.Address);

            foreach (var contactPhoneDto in contactDto.Phones)
            {
                var contactPhone = contact.Phones.FirstOrDefault(p => p.Id == contactPhoneDto.Id);
                if (contactPhone == null)
                {
                    contact.AddPhone(contactPhoneDto.PhoneNumber);
                }
                else
                {
                    contactPhone.SetPhoneNumber(contactPhoneDto.PhoneNumber);
                }
            }

            foreach (var contactPhone in contact.Phones)
            {
                if (contactDto.Phones.All(p => p.Id != contactPhone.Id))
                {
                    contact.RemovePhone(contactPhone);
                }
            }

            await _contactRepository.UpdateAsync(contact);

            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var contact = await _contactRepository.GetByIdAsync(id);

            await _contactRepository.DeleteAsync(contact);

            await _unitOfWork.CommitAsync();
        }
    }
}