namespace BookStore.Application.Contract.Catalog.AuthorAggregate.Queries
{
    public class AuthorQueryModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }
    }
}
