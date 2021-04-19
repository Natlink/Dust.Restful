using Dust.Restful.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dust.Restful.Core.Repositories.Interfaces
{
    public interface IUserRepository<T> : IRepository<T> where T : UserModel, new()
    {
        public T GetByUsername(string username);
    }
}
