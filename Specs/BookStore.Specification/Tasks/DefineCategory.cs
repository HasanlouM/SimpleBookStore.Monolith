using BookStore.Test.Specs.Constants;
using BookStore.Test.Specs.Models;
using BookStore.Test.Specs.Models.Catalog;
using Screenplay.Core.Models;
using Screenplay.Core.Models.Actors;
using Screenplay.Rest.Screenplay.Interactions;
using Screenplay.Rest.Screenplay.Questions;

namespace BookStore.Test.Specs.Tasks
{
    internal class DefineCategory : ITask
    {
        private readonly Category _category;
        public DefineCategory(Category category)
        {
            _category = category;
        }

        public void PerformAs<T>(T actor) where T : Actor
        {
            actor.AttemptsTo(Post.DataAsJson(_category).To("Categories/Define"));
            var response = actor.AsksFor(LastResponse.Content<ApiResponse<Category>>());
            actor.Remember(Keys.Categories.CategoryId, response.Data.Id);
        }
    }
}
