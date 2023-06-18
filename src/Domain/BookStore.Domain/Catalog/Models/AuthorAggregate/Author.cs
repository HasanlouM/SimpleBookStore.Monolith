using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Domain.Catalog.Core;
using Common.Domain;
using Common.Domain.Core;

namespace BookStore.Domain.Catalog.Models.AuthorAggregate
{
    public class Author: AggregateRoot<int>
    {
        private Author() { }

        public Author(string firstName, string lastName, string bio)
        {
            Guard.NotNullOrEmpty(firstName, Label.Author_FirstName);
            Guard.NotNullOrEmpty(lastName, Label.Author_LastName);

            FirstName = firstName;
            LastName = lastName;
            Bio = bio;
            Status = AuthorStatus.Active;
            CreatedAt = DateTime.UtcNow;
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Bio { get; private set; }
        public AuthorStatus Status { get; private set; }

        public void Inactivate()
        {
            Status = AuthorStatus.Inactive;
        }

        public void Activate()
        {
            Status = AuthorStatus.Active;
        }
    }
}
