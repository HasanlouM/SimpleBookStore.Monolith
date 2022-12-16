using Microsoft.AspNetCore.Http;

namespace BookStore.Application.Contract.Books.Queries;

public class BookQueryModel
{
    public int Id { get; set; }
    public string Category { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string Isbn { get; set; }
    public string Author { get; set; }
    public decimal Price { get; set; }
    public int PublishYear { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }

}