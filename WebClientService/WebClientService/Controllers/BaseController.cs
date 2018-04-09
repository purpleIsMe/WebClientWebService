using System.Web.Mvc;
using WebClientService.Common;
using System.Web.Routing;
namespace WebClientService.Controllers
{
    public class BaseController:Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var sesson = Session[Constants.THISINH_SESSION];
            if (sesson == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Index" }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}