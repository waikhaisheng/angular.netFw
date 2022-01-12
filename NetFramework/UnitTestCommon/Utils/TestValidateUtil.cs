using Common.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestCommon.Utils
{
    [TestClass]
    public class TestValidateUtil
    {
        [TestMethod]
        public void TestValidateEmail()
        {
            var email = "abc@gmail.com";
            var ret = ValidateUtil.ValidateEmail(email);
            Assert.IsTrue(ret);

            email = "abc.gmail.com";
            ret = ValidateUtil.ValidateEmail(email);
            Assert.IsFalse(ret);
        }
        [TestMethod]
        public void TestValidatePhone()
        {
            var phone = "123456789";
            var ret = ValidateUtil.ValidatePhone(phone);
            Assert.IsTrue(ret);
        }
    }
}
