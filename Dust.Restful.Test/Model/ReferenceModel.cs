using Dust.ORM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dust.Restful.Test.Model
{
    class ReferenceModel : DataModel
    {
        [Property(false, 10, null)]
        public int TestValue { get; set; }

        [ForeignID(typeof(SubReferenceA))]
        public int ReferenceA { get; set; }
        public SubReferenceA ReferenceA_ref { get; set; }

        [ForeignID(typeof(SubReferenceB))]
        public int ReferenceB { get; set; }
        public SubReferenceB ReferenceB_ref { get; set; }

        public ReferenceModel()
        {
        }

        public ReferenceModel(int id, int testValue, int referenceA, SubReferenceA referenceA_ref, int referenceB, SubReferenceB referenceB_ref) : base(id)
        {
            TestValue = testValue;
            ReferenceA = referenceA;
            ReferenceA_ref = referenceA_ref;
            ReferenceB = referenceB;
            ReferenceB_ref = referenceB_ref;
        }

        public override string ToString()
        {
            return "ReferenceModel{id: " + ID + ", TestValue: " + TestValue + "}";
        }
    }

    class SubReferenceA : DataModel
    {
        [Property(false, 10, null)]
        public int SubValue { get; set; }

        public SubReferenceA(int id, int subValue) : base(id)
        {
            SubValue = subValue;
        }

        public SubReferenceA()
        {
        }

        public override string ToString()
        {
            return "SubReferenceA{id: " + ID + ", SubValue: " + SubValue + "}";
        }
    }

    class SubReferenceB : DataModel
    {
        [Property(false, 10, null)]
        public int SubValue { get; set; }

        public SubReferenceB(int id, int subValue) : base(id)
        {
            SubValue = subValue;
        }

        public SubReferenceB()
        {
        }

        public override string ToString()
        {
            return "SubReferenceB{id: " + ID + ", SubValue: " + SubValue + "}";
        }
    }

}
