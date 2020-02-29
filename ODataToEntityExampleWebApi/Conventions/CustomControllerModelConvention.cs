using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Routing;

namespace ODataToEntityExampleWebApi.Conventions
{
    public class CustomControllerModelConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            foreach (var action in controller.Actions)
            {
                Apply(action, controller.ControllerName);
            }
        }

        private static void Apply(ActionModel action, string controllerTemplate)
        {
            foreach (var selector in action.Selectors)
            {
                string template = selector.AttributeRouteModel?.Template;
                if (!string.IsNullOrEmpty(template))
                {
                    if (template.Length >= 3 && template[0] == '<' && template[^1] == '>')
                    {
                        string text = template.Trim('<', '>');
                        selector.AttributeRouteModel.Template = controllerTemplate + "/" + text;
                    }

                    //}
                    //if (template == null)
                    //    action.Selectors[i].AttributeRouteModel.Template = controllerTemplate;
                    //else if (template[0] == '{')
                    //{
                    //    int index;
                    //    if (template[template.Length - 1] == '}')
                    //        action.Selectors[i].AttributeRouteModel.Template = controllerTemplate + "(" + template + ")";
                    //    else if ((index = template.IndexOf("}/")) > 0)
                    //        action.Selectors[i].AttributeRouteModel.Template = controllerTemplate + "(" + template.Substring(0, index + 1) + ")" + template.Substring(index + 1);
                    //}
                    //else if (template[template.Length - 1] == ')' && template.IndexOf('(') > 1)
                    //    action.Selectors[i].AttributeRouteModel.Template = controllerTemplate + "/" + template;
                }
            }
        }
    }
}