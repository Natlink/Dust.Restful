
using Dust.Restful.Core.Models;
using Dust.Restful.Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dust.Restful.Core.Controllers
{

    public abstract class AbstractController<UserType> : AbstractController where UserType : UserModel
    {
        private ILoginService<UserType> LoginService;
        protected int RequieredAuthLevel;

        protected UserType LogedUser { get; private set; }

        public AbstractController(ILoginService<UserType> loginService, int authLevel)
        {
            LoginService = loginService;
            RequieredAuthLevel = authLevel;
        }

        public override bool IsLoged()
        {
            if (RequieredAuthLevel == -1) return true;
            if (Request.Headers.ContainsKey("x-auth-token"))
            {
                string token = Request.Headers["x-auth-token"];
                LogedUser = LoginService.UserIsConnected(token);
                return LogedUser != null;
            }
            return false;
        }

        public override bool IsAuthorized(int minRequieredAccountLevel)
        {
            if (RequieredAuthLevel == -1) return true;
            return LogedUser != null && (int)LogedUser.AccountLevel >= minRequieredAccountLevel;
        }



    }

    public abstract class AbstractController : ControllerBase
    {

        public virtual bool IsLoged()
        {
            return true;
        }

        public virtual bool IsAuthorized(int minRequieredAccountLevel = 0)
        {
            return true;
        }

        public virtual bool IsLogedAndAuthorized(int minRequieredAccountLevel = 0)
        {
            return IsLoged() && IsAuthorized(minRequieredAccountLevel);
        }
    }

}
