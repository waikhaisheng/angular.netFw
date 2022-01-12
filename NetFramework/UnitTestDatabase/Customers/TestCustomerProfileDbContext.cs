using Database.Customers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestDatabase.Customers
{
    [TestClass]
    public class TestCustomerProfileDbContext
    {
        private static CustomerProfileDbContext _dbContext = new CustomerProfileDbContext("Data Source=localhost;Initial Catalog=AngularNetFw;User Id=sa;Password=pass123;");
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
            var cp = _dbContext.GetCustomerProfiles();
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
            var cp = _dbContext.AddCustomerProfile(_customerProfile);
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
            var cp = _dbContext.UpdateCustomerProfile(update);
            Assert.AreEqual(update.Id, cp.Id);
            Assert.AreEqual(update.Name, cp.Name);
            Assert.AreEqual(update.Phone, cp.Phone);
            Assert.AreEqual(update.Email, cp.Email);
            Assert.AreEqual(update.Address, cp.Address);
            Assert.AreEqual(update.MailingAddress, cp.MailingAddress);
        }
        private void TestDeleteCustomerProfile()
        {
            var cp = _dbContext.DeleteCustomerProfile(_customerProfile.Id);
            Assert.IsTrue(cp);
        }
        #endregion
    }
}
