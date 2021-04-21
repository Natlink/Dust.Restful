using Dust.ORM.Core.Models;
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

        public virtual bool Add(T dm, out int id)
        {
            return DataRepo.Insert(dm, out id);
        }

        public virtual bool Add(T dm, out T res)
        {
            DataRepo.Insert(dm);
            res = DataRepo.GetLast();
            return res != null;
        }

        public virtual bool Delete(int id)
        {
            DataRepo.Delete(id);
            return true;
        }

        public virtual bool Edit(int id, T dm)
        {
            return DataRepo.Edit(dm);
        }

        public virtual T Get(int id)
        {
            return DataRepo.Get(id);
        }

        public virtual IEnumerable<T> GetAll(int raw)
        {
            return DataRepo.GetAll(raw);
        }

        public virtual T Copy(int id)
        {
            T tmp = Get(id);
            return Add(tmp, out T res) ? res : null;
        }

    }
}
