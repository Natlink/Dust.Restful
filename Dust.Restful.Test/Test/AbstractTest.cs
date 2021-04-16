using Dust.ORM.Core;
using Dust.ORM.Core.Models;
using Dust.Restful.Core.Controllers;
using Dust.Restful.Core.Models;
using Dust.Restful.Core.Repositories.Interfaces;
using Dust.Restful.Core.Services.Implementations;
using Dust.Restful.Core.Services.Interfaces;
using Dust.Restful.Test.Controllers;
using Dust.Restful.Test.Repository;
using Dust.Restful.Test.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Dust.Restful.Test.Test
{
    public abstract class AbstractTest
    {

        protected readonly TestLogger Log;
        protected ORMManager ORM;


        public AbstractTest(ITestOutputHelper output)
        {
            Log = new TestLogger(output);
            ORM = new ORMManager(Log, "OrmExtension");
        }


        public ModelTestController<T> GenerateController<T>() where T : DataModel, new()
        {
            if (ORM == null) ORM = new ORMManager(Log, "OrmExtension");

            ModelTestRepository<T> Repo = new ModelTestRepository<T>(ORM);
            ModelTestServices<T> Service = new ModelTestServices<T>(Repo);
            ModelTestController<T> Controller = new ModelTestController<T>(Service);

            return Controller;
        }

        public (LogedModelController<T>, LoginController) GenerateLogedController<T>() where T : DataModel, new()
        {
            if (ORM == null) ORM = new ORMManager(Log, "OrmExtension");

            ModelTestRepository<T> Repo = new ModelTestRepository<T>(ORM);
            DustUserRepository<DustUserModel> UserRepo = new DustUserRepository<DustUserModel>(ORM);

            ModelTestServices<T> Service = new ModelTestServices<T>(Repo);
            DustConfigurationService<Configuration> ConfigService = new DustConfigurationService<Configuration>(Log);
            DustLoginService<DustUserModel> LoginService = new DustLoginService<DustUserModel>(UserRepo, ConfigService, Log);
            LogedModelController<T> Controller = new LogedModelController<T>(Service, LoginService);
            LoginController LoginController = new LoginController(LoginService);            

            return (Controller, LoginController);
        }

        public T ResolveRequest<T>(ActionResult<T> result)
        {
            if (result.Value != null) return result.Value;
            ActionResult test = result.Result;
            if (test is OkObjectResult) return (T)((OkObjectResult)test).Value;
            return default(T);
        }

    }
}
