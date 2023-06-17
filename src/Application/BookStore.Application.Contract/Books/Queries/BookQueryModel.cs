namespace BookStore.Application.Contract.Books.Queries;

public class BookQueryModel
{
    public int Id { get; set; }
    public string Category { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Publisher { get; set; }
    public DateOnly PublicationDate { get; set; }
    public string Isbn { get; set; }
    public decimal Price { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }

}