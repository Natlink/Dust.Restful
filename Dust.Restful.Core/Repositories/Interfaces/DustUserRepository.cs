using Dust.ORM.Core;
using Dust.ORM.Core.Databases;
using Dust.Restful.Core.Models;
using Dust.Restful.Core.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dust.Restful.Core.Repositories.Interfaces
{
    public class DustUserRepository<T> : AbstractRepository<T> where T : DustUserModel, new()
    {
        public DustUserRepository(ORMManager orm) : base(orm)
        {
        }

        public T GetByUsername(string username)
        {
            if (username.IndexOfAny(new char[] { '*', '"', '\'', '=', '&', '#', '\\', '/', '\n', '\t' }) != -1) return null;
            var res = Repo.Get(new RequestDescriptor("Login", RequestOperator.Equal, username));
            return res.Count > 0? res[0] : null;
        }

    }
}
