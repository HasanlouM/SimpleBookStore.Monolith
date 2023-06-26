using Common.Application;

namespace BookStore.Application.Contract.Catalog.AuthorAggregate.Commands
{
    public class DefineAuthorCommand: ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
    }
}
