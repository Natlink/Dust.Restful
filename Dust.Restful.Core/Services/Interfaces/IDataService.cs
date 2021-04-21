
using Dust.ORM.Core.Models;
using Dust.Restful.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dust.Restful.Core.Services.Interfaces
{
    public interface IDataService { }

    public interface IDataService<T> : IDataService where T : DataModel
    {
        T Get(int id);
        T Copy(int id);
        IEnumerable<T> GetAll(int row);
        bool Edit(int id, T dm);
        bool Add(T dm);
        bool Add(T dm, out T res);
        bool Delete(int id);
    }

    public interface IDataService<T, UserType> : IDataService where T : DataModel where UserType : UserModel
    {
        T Get(UserType user, int id);
        T Copy(UserType user, int id);
        IEnumerable<T> GetAll(UserType user, int row);
        bool Edit(UserType user, int id, T dm);
        bool Add(UserType user, T dm);
        bool Add(UserType user, T dm, out T res);
        bool Delete(UserType user, int id);
    }
}
