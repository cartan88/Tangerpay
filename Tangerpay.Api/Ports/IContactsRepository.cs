using Tangerpay.Domain.Entities;

namespace Tangerpay.Api.Ports
{
    public interface IContactsRepository
    {
        Task<int> CreateContact(Contact contact);

        Contact GetContact(int contactId);
       
    }
}
