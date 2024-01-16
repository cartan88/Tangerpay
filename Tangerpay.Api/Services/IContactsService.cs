using Tangerpay.Domain.Entities;

namespace Tangerpay.Api.Services
{
    public interface IContactsService
    {
        Contact GetContact(int contactId);

        int CreateContact(Contact contact);
    }
}
