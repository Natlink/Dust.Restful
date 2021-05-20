using Dust.ORM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dust.Restful.Core.Repositories.Interfaces
{
    public interface IRepository<T> where T : DataModel, new()
    {
        public List<T> GetAll(int row);
        public T Get(long id);
        public bool Exist(long id);
        public void Delete(long id);
        public bool Insert(T data);
        public bool Insert(T data, out long id);
        public T GetLast();
        public bool Edit(T data);
    }
}
