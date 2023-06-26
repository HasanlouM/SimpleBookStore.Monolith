using Common.Application;

namespace BookStore.Application.Contract.Catalog.PublisherAggregate.Commands
{
    public class DefinePublisherCommand : ICommand
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
