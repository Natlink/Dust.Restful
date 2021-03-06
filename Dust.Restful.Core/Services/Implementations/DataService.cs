using Dust.ORM.Core.Models;
using Dust.Restful.Core.Models;
using Dust.Restful.Core.Repositories.Interfaces;
using Dust.Restful.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dust.Restful.Core.Services.Implementations
{
    public abstract class DataService<T> : IDataService<T> where T : DataModel, new()
    {

        protected IRepository<T> DataRepo;

        public DataService(IRepository<T> dataRepo)
        {
            DataRepo = dataRepo;
        }

        public virtual bool Add(T dm)
        {
            return DataRepo.Insert(dm);
        }

        public virtual bool Add(T dm, out long id)
        {
            return DataRepo.Insert(dm, out id);
        }

        public virtual bool Add(T dm, out T res)
        {
            DataRepo.Insert(dm);
            res = DataRepo.GetLast();
            return res != null;
        }

        public virtual bool Delete(long id)
        {
            DataRepo.Delete(id);
            return true;
        }

        public virtual bool Edit(long id, T dm)
        {
            return DataRepo.Edit(dm);
        }

        public virtual T Get(long id)
        {
            return DataRepo.Get(id);
        }

        public virtual IEnumerable<T> GetAll(int raw)
        {
            return DataRepo.GetAll(raw);
        }

        public virtual T Copy(long id)
        {
            T tmp = Get(id);
            return Add(tmp, out T res) ? res : null;
        }

    }

    public abstract class DataService<T, UserType> : IDataService<T, UserType> where T : DataModel, new() where UserType : UserModel
    {

        protected IRepository<T> DataRepo;

        public DataService(IRepository<T> dataRepo)
        {
            DataRepo = dataRepo;
        }

        public virtual bool Add(UserType user, T dm)
        {
            return DataRepo.Insert(dm);
        }

        public virtual bool Add(UserType user, T dm, out long id)
        {
            return DataRepo.Insert(dm, out id);
        }

        public virtual bool Add(UserType user, T dm, out T res)
        {
            DataRepo.Insert(dm);
            res = DataRepo.GetLast();
            return res != null;
        }

        public virtual bool Delete(UserType user, long id)
        {
            DataRepo.Delete(id);
            return true;
        }

        public virtual bool Edit(UserType user, long id, T dm)
        {
            return DataRepo.Edit(dm);
        }

        public virtual T Get(UserType user, long id)
        {
            return DataRepo.Get(id);
        }

        public virtual IEnumerable<T> GetAll(UserType user, int raw)
        {
            return DataRepo.GetAll(raw);
        }

        public virtual T Copy(UserType user, long id)
        {
            T tmp = Get(user, id);
            return Add(user, tmp, out T res) ? res : null;
        }

    }
}
