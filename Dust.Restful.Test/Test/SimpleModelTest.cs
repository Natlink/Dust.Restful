using Dust.ORM.Core;
using Dust.ORM.Core.Models;
using Dust.Restful.Core.Services.Implementations;
using Dust.Restful.Test.Controllers;
using Dust.Restful.Test.Model;
using Dust.Restful.Test.Repository;
using Dust.Restful.Test.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Dust.Restful.Test.Test
{
    public class SimpleModelTest
    {

        private readonly TestLogger Log;
        private ORMManager ORM;


        public SimpleModelTest(ITestOutputHelper output)
        {
            Log = new TestLogger(output);
        }

        [Fact]
        public void RestSetupTest()
        {
            ModelTestController<SimpleModel> Controller = GenerateController<SimpleModel>(); 


            Assert.True(ResolveRequest(Controller.Add(new SimpleModel(5, 42, "Value"))));

            SimpleModel value = ResolveRequest(Controller.Get(5));
            Assert.Equal(5, value.ID);
            Assert.Equal(42, value.TestValue1);
            Assert.Equal("Value", value.TestValue2);
        }


        public ModelTestController<T> GenerateController<T>() where T : DataModel, new()
        {
            if (ORM == null) ORM = new ORMManager(Log);

            ModelTestRepository<T> Repo = new ModelTestRepository<T>(ORM);
            ModelTestServices<T> Service = new ModelTestServices<T>(Repo);
            ModelTestController<T> Controller = new ModelTestController<T>(-1, Service, new LoginService());

            return Controller;
        }

        public T ResolveRequest<T>(ActionResult<T> result)
        {
            ActionResult test = result.Result;
            if (test is OkObjectResult) return (T) ((OkObjectResult)test).Value;
            return default(T);
        }

    }
}
