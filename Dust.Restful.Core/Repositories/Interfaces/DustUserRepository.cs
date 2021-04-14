using Dust.ORM.Core;
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
            return null;
        }

    }
}
