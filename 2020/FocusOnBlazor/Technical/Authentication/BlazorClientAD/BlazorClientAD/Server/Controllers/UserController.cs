using BlazorClientAD.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorClientAD.Server.Controllers
{
    [ApiController]
    public class UserController : Controller
    {
        [HttpGet("api/user/GetUser")]
        public BlazorUser GetUser()
        {
            BlazorUser objBlazorUser = new BlazorUser();

            if (this.User.Identity.IsAuthenticated)
            {
                objBlazorUser.UserName = this.User.Identity.Name;
            }
            else
            {
                objBlazorUser.UserName = ""; // Not logged in
            }

            return objBlazorUser;
        }
    }
}