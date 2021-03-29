﻿
using Dust.ORM.Core.Models;
using Dust.Restful.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dust.Restful.Core.Controllers
{
    public abstract class DataController<T> : AbstractController where T : DataModel
    {

        protected IDataService<T> DataService;

        public DataController(int authLevel, IDataService<T> dataService, ILoginService loginService) : base(loginService, authLevel)
        {
            DataService = dataService;
        }

        [HttpGet("get/{id}")]
        public virtual ActionResult<T> Get(int id)
        {
            if (IsLogedAndAuthorized(RequieredAuthLevel))
            {
                return Ok(DataService.Get(id));
            }
            return Unauthorized();
        }

        [HttpGet("copy/{id}")]
        public virtual ActionResult<T> Copy(int id)
        {
            if (IsLogedAndAuthorized(RequieredAuthLevel))
            {
                T tmp = DataService.Copy(id);
                ActionResult<T> res;
                if(tmp == null)
                {
                    res = UnprocessableEntity(tmp);
                }
                else
                {
                    res = Ok(tmp);
                }
                return res;
            }
            return Unauthorized();
        }

        [HttpGet("getall/{row}")]
        public virtual ActionResult<IEnumerable<T>> GetAll(int row)
        {
            if (IsLogedAndAuthorized(RequieredAuthLevel))
            {
                return Ok(DataService.GetAll(row));
            }
            return Unauthorized();
        }

        [HttpPost("edit/{id}")]
        public virtual ActionResult<bool> Edit(int id, T data)
        {
            if (IsLogedAndAuthorized(RequieredAuthLevel))
            {
                return Ok(DataService.Edit(id, data));
            }
            return Unauthorized();
        }

        [HttpPost("add")]
        public virtual ActionResult<bool> Add(T data)
        {
            if (IsLogedAndAuthorized(RequieredAuthLevel))
            {
                return Ok(DataService.Add(data));
            }
            return Unauthorized();
        }

        [HttpDelete("delete/{id}")]
        public virtual ActionResult<bool> Delete(int id)
        {
            if (IsLogedAndAuthorized(RequieredAuthLevel))
            {
                return Ok(DataService.Delete(id));
            }
            return Unauthorized();
        }
    }
}