using Dust.ORM.Core.Models;
using Dust.Restful.Core.Controllers;
using Dust.Restful.Core.Services.Interfaces;
using Dust.Restful.Test.Model;
using Dust.Restful.Test.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dust.Restful.Test.Controllers
{
    public class ModelTestController<T> : DataController<T> where T: DataModel, new()
    {
        public ModelTestController(IDataService<T> dataService) : base(dataService)
        {
        }

        public ActionResult<Y> TestValue<Y>(Y value)
        {
            return Ok((DataService as ModelTestServices<T>).TestValue<Y>(value));
        }
    }
}
