using System;
using TechTalk.SpecFlow;

namespace BookStore.Test.Specs.StepDefinitions
{
    [Binding]
    public class ManagingTheCategoryStepDefinitions
    {
        [Given(@"I have entered as a store manager")]
        public void GivenIHaveEnteredAsAStoreManager()
        {
        }

        [When(@"I define a category of '([^']*)'")]
        public void WhenIDefineACategoryOf(string categoryName)
        {
        }

        [Then(@"I should see '([^']*)' in the list of categories")]
        public void ThenIShouldSeeInTheListOfCategories(string categoryName)
        {
        }
    }
}
