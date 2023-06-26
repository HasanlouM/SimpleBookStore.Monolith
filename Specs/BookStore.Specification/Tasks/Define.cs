using BookStore.Test.Specs.Models.Catalog;
using Screenplay.Core.Models;

namespace BookStore.Test.Specs.Tasks
{
    internal static class Define
    {
        public static ITask Category(Category category)
        {
            return new DefineCategory(category);
        }
    }
}