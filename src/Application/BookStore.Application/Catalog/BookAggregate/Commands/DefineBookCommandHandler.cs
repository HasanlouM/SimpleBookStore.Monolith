﻿using BookStore.Application.Contract.Catalog.BookAggregate.Commands;
using BookStore.Application.Contract.Catalog.BookAggregate.Queries;
using BookStore.Domain.Catalog.Models.BookAggregate;
using Common.Application;
using Common.Application.Utils;
using Common.Persistence.EF;

namespace BookStore.Application.Catalog.BookAggregate.Commands
{
    public class DefineBookCommandHandler
        : ICommandHandler<DefineBookCommand, BookQueryModel>
    {
        private readonly IUnitOfWork _uow;
        private readonly IBookRepository _repository;

        public DefineBookCommandHandler(
            IUnitOfWork uow,
            IBookRepository repository)
        {
            _uow = uow;
            _repository = repository;
        }

        public async Task<BookQueryModel> HandleAsync(
            DefineBookCommand command, CancellationToken cancellation = default)
        {
            var model = new Book(command.CategoryId, command.Title, command.PublisherId, command.Isbn,
                command.AuthorId, command.Price, command.PublicationDate, command.Image?.ToByte() ?? null, command.Description);

            var book = await _repository.Add(model, cancellation);
            await _uow.SaveChanges(cancellation);

            return new BookQueryModel
            {
                Id = book.Id,
                Title = book.Title,
                Publisher = "book.PublisherId",
                Author = "",
                Isbn = book.Isbn,
                Price = book.Price,
                PublicationDate = book.PublicationDate,
                Description = book.Description,
                Image = Convert.ToBase64String(book.Image)
            };
        }
    }
}