
using Dust.Restful.Core.Informations.Logins;
using Dust.Restful.Core.Models;
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
    public class LoginController : AbstractController<DustUserModel>
    {
        ILoginService<DustUserModel> LoginService;

        public LoginController(ILoginService<DustUserModel> loginService) : base(loginService, -1)
        {
            LoginService = loginService;
        }

        [HttpPost("login")]
        public ActionResult<LoginAnswer> WantLogin(LoginInformation infos)
        {
            if (IsLoged()) return new LoginAnswer(3);
            DustUserModel u = LoginService.LoginUser(infos.Username, infos.Password, out int errorCode);
            return errorCode != 0 ?
                Ok(new LoginAnswer(errorCode)) :
                Ok(new LoginAnswer(u.Token, u.Login, u.ID, (int)u.AccountLevel));

        }

        [HttpGet("logout")]
        public ActionResult Logout()
        {
            if (IsLoged())
            {
                LoginService.LogoutUser(Request.Headers["x-auth-token"]);
                return Ok();
            }
            return Forbid();
        }
    }

}
