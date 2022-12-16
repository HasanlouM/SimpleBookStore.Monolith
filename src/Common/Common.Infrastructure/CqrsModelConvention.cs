using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Common.Infrastructure
{
    public class CqrsModelConvention : IApplicationModelConvention
    {
        private const string Query = "QueryController";

        public void Apply(ApplicationModel application)
        {
            foreach (var controller in application.Controllers
                .Where(a => a.ControllerType.Name.EndsWith(Query, StringComparison.OrdinalIgnoreCase)))
            {
                foreach (var selectorModel in controller.Selectors
                    .Where(x => x.AttributeRouteModel != null).ToList())
                {
                    var template = selectorModel.AttributeRouteModel?.Template;
                    selectorModel.AttributeRouteModel =
                        new AttributeRouteModel
                        {
                            Template = "api/v{version:apiVersion}/" + controller.ControllerType.Name.Replace(
                                Query, "", StringComparison.OrdinalIgnoreCase)
                        };
                }

                if (controller.ControllerType.Name.EndsWith(Query))
                {
                    controller.ControllerName = controller.ControllerName[..^5];
                }
            }
        }
    }
}