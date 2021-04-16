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

    public class LoginAnswer
    {
        public string Token { get; set; }
        public string Name { get; set; }
        public int ID { get; set; }
        public int AccountLevel { get; set; }

        public int ErrorCode { get; set; }

        public LoginAnswer(string token, string name, int iD, int accountLevel)
        {
            Token = token;
            Name = name;
            ID = iD;
            AccountLevel = accountLevel;
            ErrorCode = 0;
        }

        public LoginAnswer(int errorCode)
        {
            ErrorCode = errorCode;
            Token = "";
            Name = "";
            ID = -1;
            AccountLevel = 0;
        }

        public LoginAnswer()
        {
        }
    }
}
