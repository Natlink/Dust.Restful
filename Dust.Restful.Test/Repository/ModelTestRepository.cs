using Dust.ORM.Core;
using Dust.ORM.Core.Models;
using Dust.Restful.Core.Repositories.Implementations;
using Dust.Restful.Test.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dust.Restful.Test.Repository
{
    class ModelTestRepository<T> : AbstractRepository<T> where T : DataModel, new()
    {
        public ModelTestRepository(ORMManager orm) : base(orm)
        {
        }
    }
}
