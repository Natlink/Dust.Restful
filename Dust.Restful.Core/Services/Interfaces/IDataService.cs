
using Dust.ORM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dust.Restful.Core.Services.Interfaces
{
    public interface IDataService<T> where T : DataModel
    {
        T Get(int id);
        T Copy(int id);
        IEnumerable<T> GetAll(int row);
        bool Edit(int id, T dm);
        bool Add(T dm);
        bool Add(T dm, out T res);
        bool Delete(int id);

    }
}
