using Dust.ORM.Core.Models;
using Dust.Restful.Core.Controllers;
using Dust.Restful.Core.Models;
using Dust.Restful.Core.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dust.Restful.Test.Controllers
{
    public class LogedModelController<T> : DataController<T> where T : DataModel, new()
    {

        public LogedModelController(DataService<T> data, DustLoginService<DustUserModel> login) : base(data)
        {
        }

    }
}
