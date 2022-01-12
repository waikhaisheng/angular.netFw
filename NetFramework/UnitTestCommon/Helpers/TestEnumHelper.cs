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
    public class TestEnumHelper
    {
        [TestMethod]
        public void TestGetEnumDescription()
        {
            var retEnumStr = TestEnumModel.Ok.GetEnumDescription();
            Assert.AreEqual("Ok", retEnumStr);

            var retErrorStr = TestEnumModel.Error.GetEnumDescription();
            Assert.AreEqual("Error", retErrorStr);
        }
    }
    public enum TestEnumModel
    {
        [System.ComponentModel.Description("Ok")]
        Ok = 1,
        Error = 400
    }
}
