using Tangerpay.Api.Ports;
using Tangerpay.Domain.Entities;

namespace Tangerpay.Api.Services
{
    public class ContactsService(IContactsRepository contactsRepository) : IContactsService
    {
        private readonly IContactsRepository contactsRepository = contactsRepository;

        public int CreateContact(Contact contact)
        {
            contact.Id = 0;
            VerifyContact(contact);
            var contactId = contactsRepository.CreateContact(contact).Result;
            return contactId;
        }

        public Contact GetContact(int contactId)
        {
            return contactsRepository.GetContact(contactId);
        }

        private static void VerifyContact(Contact contact)
        {
            if (contact.Name == string.Empty ||
                contact.PhoneNumber == string.Empty)
            {
                throw new Exception("Missing field detected");
            }
        }
    }
}
