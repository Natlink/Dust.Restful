﻿using Dust.ORM.Core.Models;
using Dust.Restful.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dust.Restful.Core.Controllers
{
    public interface IDataController<T> where T : DataModel, new()
    {

        public ActionResult<T> Get(int id);
        public ActionResult<T> Copy(int id);
        public ActionResult<IEnumerable<T>> GetAll(int row);
        public ActionResult<bool> Edit(int id, T data);
        public ActionResult<bool> Add(T data);
        public ActionResult<bool> Delete(int id);

    }
}
