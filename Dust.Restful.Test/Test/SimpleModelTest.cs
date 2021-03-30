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

        [Fact]
        public void ReferenceResolvingTest()
        {
            ModelTestController<ReferenceModel> RefController = GenerateController<ReferenceModel>();
            ModelTestController<SubReferenceA> AController = GenerateController<SubReferenceA>();
            ModelTestController<SubReferenceB> BController = GenerateController<SubReferenceB>();
            for(int i = 1; i < 11; ++i)
            {
                Assert.True(ResolveRequest(AController.Add(new SubReferenceA(i, 42 * i))));
                Assert.True(ResolveRequest(BController.Add(new SubReferenceB(i, 42 * i))));
                Assert.True(ResolveRequest(RefController.Add(new ReferenceModel(i, 42*i, i, null, i, null))));
            }

            for(int i = 1; i < 11; ++i)
            {
                ReferenceModel m = ResolveRequest(RefController.Get(i));
                Assert.NotNull(m);
                Assert.NotNull(m.ReferenceA_ref);
                Assert.NotNull(m.ReferenceB_ref);
                Assert.Equal(m.ReferenceA, m.ReferenceA_ref.ID);
                Assert.Equal(m.ReferenceB, m.ReferenceB_ref.ID);
            }
        }
    }
}
