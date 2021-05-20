
using Dust.ORM.Core.Models;
using Dust.Restful.Core.Models;
using Dust.Restful.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dust.Restful.Core.Controllers
{
    public abstract class DataController<T, UserType> : AbstractController<UserType>, IDataController<T>
        where T : DataModel, new() 
        where UserType : UserModel
    {
        public IDataService<T, UserType> DataAndUserService { get; set; }

        public DataController(int authLevel, IDataService<T, UserType> dataService, ILoginService<UserType> loginService) : base(loginService, authLevel)
        {
            DataAndUserService = dataService;
        }

        [HttpGet("get/{id}")]
        public virtual ActionResult<T> Get(long id)
        {
            if (IsLogedAndAuthorized(RequieredAuthLevel))
            {
                return Ok(DataAndUserService.Get(LogedUser, id));
            }
            return Unauthorized();
        }

        [HttpGet("copy/{id}")]
        public virtual ActionResult<T> Copy(long id)
        {
            if (IsLogedAndAuthorized(RequieredAuthLevel))
            {
                T tmp = DataAndUserService.Copy(LogedUser, id);
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
                return Ok(DataAndUserService.GetAll(LogedUser, row));
            }
            return Unauthorized();
        }

        [HttpPost("edit/{id}")]
        public virtual ActionResult<bool> Edit(long id, T data)
        {
            if (IsLogedAndAuthorized(RequieredAuthLevel))
            {
                return Ok(DataAndUserService.Edit(LogedUser, id, data));
            }
            return Unauthorized();
        }

        [HttpPost("add")]
        public virtual ActionResult<bool> Add(T data)
        {
            if (IsLogedAndAuthorized(RequieredAuthLevel))
            {
                return Ok(DataAndUserService.Add(LogedUser, data));
            }
            return Unauthorized();
        }

        [HttpDelete("delete/{id}")]
        public virtual ActionResult<bool> Delete(long id)
        {
            if (IsLogedAndAuthorized(RequieredAuthLevel))
            {
                return Ok(DataAndUserService.Delete(LogedUser, id));
            }
            return Unauthorized();
        }
    }


    public abstract class DataController<T> : AbstractController, IDataController<T> where T : DataModel, new()
    {

        public IDataService<T> DataService { get; set; }

        public DataController(IDataService<T> dataService) : base()
        {
            DataService = dataService;
        }

        [HttpGet("get/{id}")]
        public virtual ActionResult<T> Get(long id)
        {
            if (IsLogedAndAuthorized())
            {
                return Ok(DataService.Get(id));
            }
            return Unauthorized();
        }

        [HttpGet("copy/{id}")]
        public virtual ActionResult<T> Copy(long id)
        {
            if (IsLogedAndAuthorized())
            {
                T tmp = DataService.Copy(id);
                ActionResult<T> res;
                if (tmp == null)
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
            if (IsLogedAndAuthorized())
            {
                return Ok(DataService.GetAll(row));
            }
            return Unauthorized();
        }

        [HttpPost("edit/{id}")]
        public virtual ActionResult<bool> Edit(long id, T data)
        {
            if (IsLogedAndAuthorized())
            {
                return Ok(DataService.Edit(id, data));
            }
            return Unauthorized();
        }

        [HttpPost("add")]
        public virtual ActionResult<bool> Add(T data)
        {
            if (IsLogedAndAuthorized())
            {
                return Ok(DataService.Add(data));
            }
            return Unauthorized();
        }

        [HttpDelete("delete/{id}")]
        public virtual ActionResult<bool> Delete(long id)
        {
            if (IsLogedAndAuthorized())
            {
                return Ok(DataService.Delete(id));
            }
            return Unauthorized();
        }
    }

}
