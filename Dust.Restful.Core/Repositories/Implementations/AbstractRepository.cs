
using Dust.ORM.Core;
using Dust.ORM.Core.Models;
using Dust.ORM.Core.Repositories;
using Dust.Restful.Core.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dust.Restful.Core.Repositories.Implementations
{
    public abstract class AbstractRepository<T> : IRepository<T> where T : DataModel, new()
    {
        protected IORMManager ORM;
        protected DataRepository<T> Repo;

        public AbstractRepository(IORMManager orm){
            ORM = orm;
            Repo = ORM.Get<T>();
        }

        public void Delete(long id)
        {
            Repo.Delete(id);
        }

        public bool Edit(T data)
        {
            return Repo.Edit(data);
        }

        public bool Exist(long id)
        {
            return Repo.Exist(id);
        }

        public T Get(long id)
        {
            return Repo.Get(id);
        }

        public List<T> GetAll(int row)
        {
            return Repo.GetAll(row);
        }

        public T GetLast()
        {
            return Repo.GetLast();
        }

        public bool Insert(T data)
        {
            return Repo.Insert(data);
        }

        public bool Insert(T data, out long id)
        {
            return Repo.Insert(data, out id);
        }
    }
}
