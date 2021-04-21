using Dust.Restful.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dust.Restful.Core.Informations.Logins
{

    public class LoginInformation
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public LoginInformation(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public LoginInformation()
        {
        }
    }

    public class LoginAnswer<T> where T : UserModel
    {
        public T User { get; set; }

        public int ErrorCode { get; set; }

        public LoginAnswer(T user, int errorCode = 0)
        {
            User = user;
            ErrorCode = errorCode;
        }

        public LoginAnswer(int errorCode)
        {
            ErrorCode = errorCode;
            User = null;
        }

        public LoginAnswer()
        {
            ErrorCode = 3;
            User = null;
        }
    }
}
