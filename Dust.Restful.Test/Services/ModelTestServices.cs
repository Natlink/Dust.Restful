using Dust.ORM.Core.Models;
using Dust.Restful.Core.Repositories.Interfaces;
using Dust.Restful.Core.Services.Implementations;
using Dust.Restful.Test.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dust.Restful.Test.Services
{
    class ModelTestServices<T> : DataService<T> where T : DataModel, new()
    {
        public ModelTestServices(IRepository<T> dataRepo) : base(dataRepo)
        {
        }

        public Y TestValue<Y>(Y value)
        {
            return value;
        }

    }

}
