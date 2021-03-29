﻿
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
        protected ORMManager ORM;
        protected DataRepository<T> Repo;

        public AbstractRepository(ORMManager orm){
            ORM = orm;
            Repo = ORM.Get<T>();
        }

        public void Delete(int id)
        {
            Repo.Delete(id);
        }

        public bool Edit(T data)
        {
            return Repo.Edit(data);
        }

        public bool Exist(int id)
        {
            return Repo.Exist(id);
        }

        public T Get(int id)
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
    }
}