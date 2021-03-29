using Dust.ORM.Core.Models;
using Dust.Restful.Core;
using System;
using Xunit;

namespace Dust.Restful.Test.Model
{
    public class SimpleModel : DataModel
    {
        [Property(false, 11)]
        public int TestValue1 { get; set; }
        [Property(false, 255)]
        public string TestValue2 { get; set; }

        public SimpleModel(int id, int testValue1, string testValue2) : base(id)
        {
            TestValue1 = testValue1;
            TestValue2 = testValue2;
        }

        public SimpleModel()
        {
            TestValue1 = 0;
            TestValue2 = "";
        }
    }
}
