using Common.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestCommon.Helpers
{
    [TestClass]
    public class TestDbHelper
    {
        [TestMethod]
        public void TestObjectOrDefaultDBNull()
        {
            var objInt = 1;
            var retInt = objInt.ObjectOrDefaultDBNull<int>();
            Assert.AreEqual(1, retInt);

            var objDbNull = DBNull.Value;
            var retDbNull = objDbNull.ObjectOrDefaultDBNull<int>();
            Assert.AreEqual(0, retDbNull);
        }
    }
}
