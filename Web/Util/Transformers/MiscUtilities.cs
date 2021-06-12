using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Util.Transformers
{
    public static class MiscUtilities
    {
        public static bool IsTheCurrentControllerEqualTo(this IHtmlHelper htmlHelper, string controllerName)
        {
            var currentControllerName = htmlHelper.ViewContext.RouteData.Values["controller"]?.ToString();
            return currentControllerName == controllerName;
        } 
    }
}