using BookStore.Test.Specs.Models.Catalog;
using BookStore.Test.Specs.Questions;
using BookStore.Test.Specs.Tasks;
using Screenplay.Core.Models;

namespace BookStore.Test.Specs.StepDefinitions
{
    [Binding]
    public class ManagingTheCategoryStepDefinitions
    {
        private Category _category;
        private Stage _stage;

        public ManagingTheCategoryStepDefinitions(Stage stage)
        {
            _stage = stage;
        }

        [Given(@"I have entered as a store manager")]
        public void GivenIHaveEnteredAsAStoreManager()
        {
            _stage.ShineSpotlightOn("Store Manager");
        }

        [When(@"I define a category of '([^']*)'")]
        public void WhenIDefineACategoryOf(string categoryName)
        {
            _category = new Category
            {
                Name = categoryName
            };
            _stage.ActorInTheSpotlight.AttemptsTo(Define.Category(_category));
        }

        [Then(@"I should see '([^']*)' in the list of categories")]
        public void ThenIShouldSeeInTheListOfCategories(string categoryName)
        {
            var actualCategory = _stage.ActorInTheSpotlight.AsksFor(new LastCreatedCategory());

            actualCategory.Should().BeEquivalentTo(_category, config => config.Excluding(c => c.Id));
        }
    }
}
