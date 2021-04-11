using Lambda;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LambdaTest
{
    [TestClass]
    public class LambdaTest
    {
        [TestMethod]
        public void Lambda_Select()
        {
            VectorList<TestType> vl = new VectorList<TestType>(3);
            vl[0] = new TestType { A = "abc", B = 1, C = 1.5 };
            vl[1] = new TestType { A = "def", B = 2, C = 2.5 };
            vl[2] = new TestType { A = "ghi", B = 3, C = 3.5 };

            Assert.AreEqual(3, vl.Length);

            VectorList<TargetType> target = vl.Select(x => new TargetType { A1 = x.A, B1 = x.B, C = x.C });

            Assert.AreEqual(vl.Length, target.Length);
            Assert.IsInstanceOfType(target[0], typeof(TargetType));
        }

        [TestMethod]
        public void Lambda_Where()
        {
            VectorList<TestType> vl = new VectorList<TestType>(3);
            vl[0] = new TestType { A = "abc", B = 1, C = 1.5 };
            vl[1] = new TestType { A = "def", B = 2, C = 2.5 };
            vl[2] = new TestType { A = "ghi", B = 3, C = 3.5 };

            VectorList<TestType> vres = vl.Where(x => x.B == 2 || x.B==3);

            Assert.AreEqual(2, vres.Length);

            Assert.AreEqual("def", vres[0].A);
            Assert.AreEqual("ghi", vres[1].A);
        }
    }

    public class TargetType
    {
        public String A1 { get; set; }
        public int B1 { get; set; }
        public double C { get; set; }
    }

    public class TestType
    {
        public String A { get; set; }
        public int B { get; set; }
        public double C { get; set; }
    }
}
