namespace ZooRestaurant.Web.Attributes
{
    using System.Linq;
    using System.Web.Mvc;

    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var roles = this.Roles.Split(',').Select(s => s.Trim());

            if (filterContext.HttpContext.Request.IsAuthenticated && !roles.Any(s => filterContext.HttpContext.User.IsInRole(s)))
            {
                filterContext.Result = new ViewResult()
                {
                    ViewName = "~/Views/Shared/_UnAuthorize.cshtml"
                };
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}