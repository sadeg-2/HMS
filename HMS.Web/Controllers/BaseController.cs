using HMS.Infrastructure.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HMS.Web.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        protected readonly IUserService _userService;
        protected string userType;
        protected string userId;

        public BaseController(IUserService userService)
        {
            _userService = userService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            if (User.Identity.IsAuthenticated)
            {
                var userName = User.Identity.Name;
                var user = _userService.GetUserByUsername(userName);
                userId = user.Id;
                userType = user.UserType;
                ViewBag.fullName = user.FullName;
                ViewBag.image = user.ImageUrl;
                ViewBag.UserType = user.UserType.ToString();
            }
        }
    }
}
