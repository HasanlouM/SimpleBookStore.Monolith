using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;

namespace BookStore.Application.Contract.Catalog.InventoryAggregate.Commands
{
    public class AddBookToInventoryCommand: ICommand
    {
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public int ReorderThreshold { get; set; }
    }
}
