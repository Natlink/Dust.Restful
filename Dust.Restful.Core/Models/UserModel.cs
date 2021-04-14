using Dust.ORM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dust.Restful.Core.Models
{
    public class UserModel : DataModel
    {
        [Property(true, 256, "")] public string Login { get; set; }
        [Property(true, 256, "")] public string Password { get; set; }
        [Property(true, 4, "0")] public int AccountLevel { get; set; }

        public UserModel(int id, string login, string password, int accountLevel) : base(id)
        {
            Login = login;
            Password = password;
            AccountLevel = accountLevel;
        }

        public UserModel() : base()
        {
            Login = "";
            Password = "";
        }
    }
}
