using Tangerpay.Domain.Entities;

namespace Tangerpay.Data.DataContexts
{
    public class DataSeeder(DataContext dataContext)
    {
        private readonly DataContext dataContext = dataContext;

        public void Seed()
        {
            var contactDetail = new Contact(0, "Default Name", "Default Phone Number");

            dataContext.Add(contactDetail);
            dataContext.SaveChanges();
        }
    }
}
