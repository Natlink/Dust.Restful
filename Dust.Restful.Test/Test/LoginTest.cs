using Dust.Restful.Core.Models;
using Dust.Restful.Test.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Dust.Restful.Test.Test
{
    [Collection("Test")]
    public class LoginTest : AbstractTest
    {
        public LoginTest(ITestOutputHelper output) : base(output)
        {
        }


        [Fact]
        public void TestLogin()
        {
            var res = GenerateLogedController<SimpleModel>();
            var Login = res.Item2;
            var Data = res.Item1;

            Assert.True(ORM.Get<DustUserModel>().Insert(new DustUserModel(0, "username", "password", 0,null)));

            var loginAnswer = ResolveRequest(Login.WantLogin(new Core.Informations.Logins.LoginInformation("username", "password")));
            Assert.NotNull(loginAnswer);

        }
    }
}
