using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Entities;
using Services.CustomerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestService.CustomerServices
{
    [TestClass]
    public class TestCustomerService
    {
        private CustomerService _srv;
        public TestCustomerService()
        {
            _srv = new CustomerService();
        }
        private CustomerProfile _customerProfile = new CustomerProfile()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            Name = "Name1",
            Phone = "123456789",
            Email = "unittest1@gmail.com",
            Address = "Address1",
            MailingAddress = "MailingAddress1",
        };
        [TestMethod]
        public void TestGetCustomerProfiles()
        {
            var cp = _srv.GetCustomerProfiles();
        }
        [TestMethod]
        public void TestCustomerProfile_Add_Update_Delete()
        {
            TestAddCustomerProfile();
            TestUpdateCustomerProfile();
            TestDeleteCustomerProfile();
        }

        #region Private Testcases
        private void TestAddCustomerProfile()
        {
            var cp = _srv.AddCustomerProfile(_customerProfile);
            Assert.AreEqual(_customerProfile.Id, cp.Id);
            Assert.AreEqual(_customerProfile.Name, cp.Name);
            Assert.AreEqual(_customerProfile.Phone, cp.Phone);
            Assert.AreEqual(_customerProfile.Email, cp.Email);
            Assert.AreEqual(_customerProfile.Address, cp.Address);
            Assert.AreEqual(_customerProfile.MailingAddress, cp.MailingAddress);
        }
        private void TestUpdateCustomerProfile()
        {
            var update = new CustomerProfile()
            {
                Id = _customerProfile.Id,
                Name = "Update name",
                Phone = "987654321",
                Email = "Update@mail.com",
                Address = "Update Address",
                MailingAddress = "Update MailingAddress"
            };
            var cp = _srv.UpdateCustomerProfile(update);
            Assert.AreEqual(update.Id, cp.Id);
            Assert.AreEqual(update.Name, cp.Name);
            Assert.AreEqual(update.Phone, cp.Phone);
            Assert.AreEqual(update.Email, cp.Email);
            Assert.AreEqual(update.Address, cp.Address);
            Assert.AreEqual(update.MailingAddress, cp.MailingAddress);
        }
        private void TestDeleteCustomerProfile()
        {
            var cp = _srv.DeleteCustomerProfile(_customerProfile.Id);
            Assert.IsTrue(cp);
        }
        #endregion
    }
}
