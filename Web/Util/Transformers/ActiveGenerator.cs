using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Util.Transformers
{
    public static class ActiveGenerator
    {
        public  static string Check(this IHtmlHelper htmlHelper, string controller, string action)
        {
            var routeData = htmlHelper.ViewContext.RouteData;
            var actionData = routeData.Values["action"]?.ToString();
            var controllerData = routeData.Values["controller"]?.ToString();

            return controller == controllerData && action == actionData ? "active" : "";
        }
    }
}