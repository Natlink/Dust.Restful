
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

    public class DustLoginController : AbstractController<DustUserModel>
    {
        ILoginService<DustUserModel> LoginService;

        public DustLoginController(ILoginService<DustUserModel> loginService) : base(loginService, -1)
        {
            LoginService = loginService;
        }

        [HttpPost("login")]
        public ActionResult<LoginAnswer<DustUserModel>> WantLogin(LoginInformation infos)
        {
            if (IsLoged()) return new LoginAnswer<DustUserModel>(3);
            DustUserModel u = LoginService.LoginUser(infos.Username, infos.Password, out int errorCode);
            return errorCode != 0 ?
                Ok(new LoginAnswer<DustUserModel>(errorCode)) :
                Ok(new LoginAnswer<DustUserModel>(u));

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
