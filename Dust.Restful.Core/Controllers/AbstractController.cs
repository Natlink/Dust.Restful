
using Dust.Restful.Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dust.Restful.Core.Controllers
{
    public abstract class AbstractController : ControllerBase
    {
        private ILoginService LoginService;
        protected int RequieredAuthLevel;

        public AbstractController(ILoginService loginService, int authLevel) 
        {
            LoginService = loginService;
            RequieredAuthLevel = authLevel;
        }
        
       // protected LogedUser LogedUser { get; private set; }
        public bool IsLoged()
        {
            if (RequieredAuthLevel == -1) return true;
            if (Request.Headers.ContainsKey("x-auth-token"))
            {
                return true;
                /*
                string token = Request.Headers["x-auth-token"];
                LogedUser = LoginService.UserIsConnected(token);
                return LogedUser != null && !LogedUser.IsTimeout;
                */
            }
            return false;
        }

        public bool IsAuthorized(int minRequieredAccountLevel)
        {
            if (RequieredAuthLevel == -1) return true;
            return true; // LogedUser != null && (int)LogedUser.AccountLevel >= minRequieredAccountLevel;
        }

        public bool IsLogedAndAuthorized(int minRequieredAccountLevel)
        {
            return IsLoged() && IsAuthorized(minRequieredAccountLevel);
        }

    }
}
