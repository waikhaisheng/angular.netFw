using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Controllers.CustomerModels;
using Models.Entities;
using NetFramework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace UnitTestNetFramework.Controllers
{
    [TestClass]
    public class TestCustomerController
    {
        private HttpServer _server;
        private string _url = "https://localhost";
        private string _profileUrl = "api/Customer/Profile";
        private CustomerProfile _customerProfile = new CustomerProfile()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            Name = "Name1",
            Phone = "123456789",
            Email = "unittest1@gmail.com",
            Address = "Address1",
            MailingAddress = "MailingAddress1",
        };
        public TestCustomerController()
        {
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            _server = new HttpServer(config);
        }
        [TestMethod]
        public void TestGetCustomerProfile()
        {
            var url = $"{_url}/{_profileUrl}";
            var httpMethod = HttpMethod.Get;
            var httpClient = new HttpClient(_server);
            HttpStatusCode statusCode = HttpStatusCode.BadRequest;

            using (var httpReqMsg = new HttpRequestMessage(httpMethod, url))
            {
                var response = httpClient.SendAsync(httpReqMsg).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    statusCode = response.StatusCode;
                }
            }
            Assert.AreEqual(HttpStatusCode.OK, statusCode);
        }
        [TestMethod]
        public void TestCustomerProfile_Add_Update_Delete()
        {
            TestAddCustomerProfile();
            TestUpdateCustomerProfile();
            TestActionDelete();
        }

        #region Private TestCases
        private void TestAddCustomerProfile()
        {
            // Arrange
            var url = $"{_url}/{_profileUrl}";
            var httpMethod = HttpMethod.Post;
            var httpClient = new HttpClient(_server);
            HttpStatusCode statusCode = HttpStatusCode.BadRequest;
            var ret = new AddCustomerProfileRes();
            var paramObj = _customerProfile;

            // Act
            using (var httpReqMsg = new HttpRequestMessage(httpMethod, url))
            {
                httpReqMsg.Content = new StringContent(JsonConvert.SerializeObject(paramObj), Encoding.UTF8, "application/json");
                var response = httpClient.SendAsync(httpReqMsg).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    ret = JsonConvert.DeserializeObject<AddCustomerProfileRes>(responseContent);
                    statusCode = response.StatusCode;
                }
            }
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, statusCode);
            Assert.AreEqual(_customerProfile.Id, ret?.Result?.Id);
            Assert.AreEqual(_customerProfile.Name, ret?.Result?.Name);
            Assert.AreEqual(_customerProfile.Phone, ret?.Result?.Phone);
            Assert.AreEqual(_customerProfile.Email, ret?.Result?.Email);
            Assert.AreEqual(_customerProfile.Address, ret?.Result?.Address);
            Assert.AreEqual(_customerProfile.MailingAddress, ret?.Result?.MailingAddress);
        }
        private void TestUpdateCustomerProfile()
        {
            // Arrange
            var url = $"{_url}/{_profileUrl}";
            var httpMethod = HttpMethod.Put;
            var httpClient = new HttpClient(_server);
            HttpStatusCode statusCode = HttpStatusCode.BadRequest;
            var ret = new UpdateCustomerProfileRes();
            var paramObj = new CustomerProfile()
            {
                Id = _customerProfile.Id,
                Name = "NameUpdate",
                Phone = "987654321",
                Email = "unittestupdate@gmail.com",
                Address = "AddressUpdate",
                MailingAddress = "MailingAddressUpdate",
            };

            // Act
            using (var httpReqMsg = new HttpRequestMessage(httpMethod, url))
            {
                httpReqMsg.Content = new StringContent(JsonConvert.SerializeObject(paramObj), Encoding.UTF8, "application/json");
                var response = httpClient.SendAsync(httpReqMsg).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    ret = JsonConvert.DeserializeObject<UpdateCustomerProfileRes>(responseContent);
                    statusCode = response.StatusCode;
                }
            }
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, statusCode);
            Assert.AreEqual(paramObj.Id, ret?.Result?.Id);
            Assert.AreEqual(paramObj.Name, ret?.Result?.Name);
            Assert.AreEqual(paramObj.Phone, ret?.Result?.Phone);
            Assert.AreEqual(paramObj.Email, ret?.Result?.Email);
            Assert.AreEqual(paramObj.Address, ret?.Result?.Address);
            Assert.AreEqual(paramObj.MailingAddress, ret?.Result?.MailingAddress);
        }
        private void TestActionDelete()
        {
            // Arrange
            var url = $"{_url}/{_profileUrl}/{_customerProfile.Id}";
            var httpMethod = HttpMethod.Delete;
            var httpClient = new HttpClient(_server);
            HttpStatusCode statusCode = HttpStatusCode.BadRequest;
            var ret = new DeleteCustomerProfileRes();

            // Act
            using (var httpReqMsg = new HttpRequestMessage(httpMethod, url))
            {
                var response = httpClient.SendAsync(httpReqMsg).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    ret = JsonConvert.DeserializeObject<DeleteCustomerProfileRes>(responseContent);
                    statusCode = response.StatusCode;
                }
            }
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, statusCode);
            Assert.AreEqual(true, ret?.Result);
        }
        #endregion
    }
}
