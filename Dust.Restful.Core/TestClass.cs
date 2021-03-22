using Dust.ORM.Core;
using Dust.Restful.Core.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dust.Restful.Core
{
    public class TestClass : ControllerBase
    {

        ORMManager Manager;
        DustLogger Logs;

        public TestClass()
        {
            Logs = new DustLogger();
            Manager = new ORMManager(Logs);
        }

    }
}
