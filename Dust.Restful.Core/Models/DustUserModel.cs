using Dust.ORM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dust.Restful.Core.Models
{
    public class DustUserModel : UserModel
    {
        public string Token { get; set; }

        public DustUserModel(int id, string login, string password, int accountLevel) : base(id, login, password, accountLevel)
        {
            Token = "";
        }

        public DustUserModel() : base()
        {
            Token = "";
        }
    }
}
