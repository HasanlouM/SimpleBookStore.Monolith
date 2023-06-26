namespace BookStore.Application.Contract.Catalog.PublisherAggregate.Queries
{
    public class PublisherQueryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
