
using Dust.Restful.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dust.Restful.Core.Services.Interfaces
{
    public interface ILoginService<T> where T : UserModel
    {

        public T UserIsConnected(string token);

        public T LoginUser(string username, string password, out int errorCode);

        public bool LogoutUser(string token);

    }
}
