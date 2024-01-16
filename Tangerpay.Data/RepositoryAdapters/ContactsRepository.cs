using Tangerpay.Api.Ports;
using Tangerpay.Data.DataContexts;
using Tangerpay.Domain.Entities;

namespace Tangerpay.Data.RepositoryAdapters
{
    public class ContactsRepository(DataContext dataContext) : IContactsRepository
    {
        private readonly DataContext dataContext = dataContext;

        public async Task<int> CreateContact(Contact contact)
        {
            await dataContext.AddAsync(contact);
            await dataContext.SaveChangesAsync();

            var contactDetails = dataContext.Contacts.Single(savedContact => savedContact.Name.Equals(contact.Name));
            return contactDetails.Id;
        }

        public Contact GetContact(int contactId)
        {
            var contactDetails = dataContext.Contacts.Single(savedContact => savedContact.Id.Equals(contactId));
            return contactDetails;
        }
    }
}

