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
        public DustPermissionModel Permission { get; set; }

        public DustUserModel(int id, string login, string password, int accountLevel, DustPermissionModel permission) : base(id, login, password, accountLevel)
        {
            Token = "";
            Permission = permission;
        }

        public DustUserModel() : base()
        {
            Token = "";
            Permission = new DustPermissionModel(false, false, false, false, false, false);
        }
    }
}
