using BookStore.Application.Contract.Catalog.BookAggregate.Commands;
using Microsoft.AspNetCore.Http;

namespace BookStore.Application.Test.Integration.Catalog;

internal class DefineBookCommandBuilder
{
    private string _title = "test";
    private int _categoryId;
    private int _publisherId;
    private string _isbn = "test";
    private int _authorId;
    private decimal _price = 100;
    private DateOnly _publicationDate = DateOnly.FromDateTime(DateTime.Now);
    private IFormFile _image;
    private string _description;

    private DefineBookCommandBuilder() { }

    public static DefineBookCommandBuilder New()
    {
        return new DefineBookCommandBuilder();
    }

    public DefineBookCommandBuilder WithTitle(string title)
    {
        _title = title;
        return this;
    }

    public DefineBookCommandBuilder WithCategory(int categoryId)
    {
        _categoryId = categoryId;
        return this;
    }

    public DefineBookCommandBuilder WrittenBy(int authorId)
    {
        _authorId = authorId;
        return this;
    }

    public DefineBookCommandBuilder PublishedBy(int publisherId)
    {
        _publisherId = publisherId;
        return this;
    }

    public DefineBookCommandBuilder WithImage(IFormFile image)
    {
        _image = image;
        return this;
    }

    public DefineBookCommand Build()
    {
        _image ??= CreateImage();

        return new DefineBookCommand
        {
            Title = _title,
            CategoryId = _categoryId,
            PublisherId = _publisherId,
            Isbn = _isbn,
            AuthorId = _authorId,
            Price = _price,
            PublicationDate = _publicationDate,
            Image = _image,
            Description = _description,
        };
    }

    private static IFormFile CreateImage()
    {
        var content = "Hello World from a Fake File";
        var fileName = "test.jpeg";
        var stream = new MemoryStream();
        var writer = new StreamWriter(stream);
        writer.Write(content);
        writer.Flush();
        stream.Position = 0;
        return new FormFile(stream, 0, stream.Length, "image", fileName);
    }
}