using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagicBox.AgileWeb.Filters
{
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.Controller.ViewData.ModelState.IsValid)
            {
                filterContext.Result = new ViewResult
                {
                    ViewData = filterContext.Controller.ViewData,
                    TempData = filterContext.Controller.TempData
                };
            }
            base.OnActionExecuting(filterContext);
        }
    }
}