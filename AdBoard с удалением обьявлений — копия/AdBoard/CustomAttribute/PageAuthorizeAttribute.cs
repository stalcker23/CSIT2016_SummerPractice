using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdBoard.Model;
namespace AdBoard.CustomAttribute
{
    public class PageAuthorizeAttribute : AuthorizeAttribute
    {
        public string UserRoles { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var authCooke = httpContext.Request.Cookies["__AUTH"];

            if (authCooke != null)
            {
                User user = DataBase.GetUserByCookeis(authCooke.Value);

                return UserRoles.Split(',').Any(r => r.Trim().ToLower() == user.Role.RoleName.Trim().ToLower());
            }

            return false;
        }
    }
}