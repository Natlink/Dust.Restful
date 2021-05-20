
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
        T Get(long id);
        T Copy(long id);
        IEnumerable<T> GetAll(int row);
        bool Edit(long id, T dm);
        bool Add(T dm);
        bool Add(T dm, out T res);
        bool Delete(long id);
    }

    public interface IDataService<T, UserType> : IDataService where T : DataModel where UserType : UserModel
    {
        T Get(UserType user, long id);
        T Copy(UserType user, long id);
        IEnumerable<T> GetAll(UserType user, int row);
        bool Edit(UserType user, long id, T dm);
        bool Add(UserType user, T dm);
        bool Add(UserType user, T dm, out T res);
        bool Delete(UserType user, long id);
    }
}
