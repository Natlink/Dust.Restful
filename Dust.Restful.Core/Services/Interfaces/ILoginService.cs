
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dust.Restful.Core.Services.Interfaces
{
    public interface ILoginService
    {


       // public LogedUser UserIsConnected(string token);

       // public LogedUser LoginUser(string username, string password, out int errorCode);

        public bool LogoutUser(string token);

    }
}
