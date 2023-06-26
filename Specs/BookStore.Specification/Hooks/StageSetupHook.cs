using BoDi;
using BookStore.Test.Specs.Constants;
using Screenplay.Core.Models;
using Screenplay.Rest.Screenplay.Abilities;
using System.Collections.Generic;

namespace BookStore.Test.Specs.Hooks
{
    [Binding]
    public class StageApiSetupHook
    {
        private readonly IObjectContainer _container;
        public StageApiSetupHook(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario]
        public void SetupStage()
        {
            var cast = Cast.WhereEveryoneCan(new List<IAbility> { CallAnApi.At(ApiConstants.BaseUrl) });
            var stage = new Stage(cast);
            _container.RegisterInstanceAs(stage);
        }
    }
}