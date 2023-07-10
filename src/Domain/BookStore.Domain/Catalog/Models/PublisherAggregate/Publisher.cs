using BookStore.Domain.Catalog.Core;
using Common.Domain;
using Common.Domain.Core;
using Common.Domain.Utils;

namespace BookStore.Domain.Catalog.Models.PublisherAggregate
{
    public class Publisher : AggregateRoot<int>
    {
        private Publisher() { }

        public Publisher(string name, string address, string phoneNumber, string email, IClock clock)
        {
            Guard.NotNullOrEmpty(name, Label.Publisher_Name);
            Guard.NotNullOrEmpty(address, Label.Publisher_Address);
            Guard.NotNullOrEmpty(phoneNumber, Label.Publisher_PhoneNumber);
            Guard.ValidEmail(email, Label.Publisher_Email);

            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
            Status = PublisherStatus.Active;
            CreatedAt = clock.Now;
        }
        public string Name { get; private set; }
        public string Address { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public PublisherStatus Status { get; private set; }

        public void Inactivate()
        {
            Status = PublisherStatus.Inactive;
        }
        public void Activate()
        {
            Status = PublisherStatus.Active;
        }
    }
}
