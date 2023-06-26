using BookStore.Test.Specs.Constants;
using BookStore.Test.Specs.Models;
using BookStore.Test.Specs.Models.Catalog;
using Screenplay.Core.Models.Actors;
using Screenplay.Core.Models.Questions;
using Screenplay.Rest.Screenplay.Interactions;
using Screenplay.Rest.Screenplay.Questions;

namespace BookStore.Test.Specs.Questions
{
    internal class LastCreatedCategory : IQuestion<Category>
    {
        public Category AnsweredBy(Actor actor)
        {
            var id = actor.Recall<int>(Keys.Categories.CategoryId);
            actor.AttemptsTo(Get.ResourceAt($"Categories/{id}/Get"));
            var response = actor.AsksFor(LastResponse.Content<ApiResponse<Category>>());
            return response.Data;
        }
    }
}
