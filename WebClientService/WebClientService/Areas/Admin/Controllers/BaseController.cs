using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebClientService.Common;
using System.Web.Routing;
namespace WebClientService.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var sesson = Session[Constants.USER_SESSION];
            if(sesson == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Index", Area = "Admin"}));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}