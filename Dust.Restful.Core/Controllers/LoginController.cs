
using Dust.Restful.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dust.Restful.Core.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class LoginController : AbstractController
    {
        ILoginService LoginService;

        public LoginController(ILoginService loginService) : base(loginService, -1)
        {
            LoginService = loginService;
        }

        /*
        [HttpPost("login")]
        public ActionResult<AllowedLoginAnswer> WantLogin(LoginInformation infos)
        {
            LogedUser u = LoginService.LoginUser(infos.Username, infos.Password, out int errorCode);
            return errorCode != 0 ?
                Ok(new AllowedLoginAnswer(errorCode)) :
                Ok(new AllowedLoginAnswer(u.Token, u.Name, u.ID, (int)u.AccountLevel));
            
        }

        [HttpGet("logout")]
        public ActionResult Logout()
        {
            if(IsLoged())
            {
                LoginService.LogoutUser(Request.Headers["x-auth-token"]);
                return Ok();
            }
            return Forbid();
        }
        */
    }
}
