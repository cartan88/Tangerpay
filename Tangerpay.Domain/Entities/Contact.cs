namespace Tangerpay.Domain.Entities
{
    public class Contact
    {
        public Contact()
        {
            Id = -1;
            Name = string.Empty;
            PhoneNumber = string.Empty;
        }

        public Contact(int id, string name, string phoneNumber)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }
    }
}

