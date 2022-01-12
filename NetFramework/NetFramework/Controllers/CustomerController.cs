using Common.Helpers;
using Models.Controllers.CustomerModels;
using Models.Entities;
using Models.Enums;
using NetFramework.Filters;
using Services.CustomerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NetFramework.Controllers
{
    [RoutePrefix("api/Customer")]
    [ApiUnhandledExceptionFilter]
    [ApiBaseActionFilter]
    public class CustomerController : ApiController
    {
        private CustomerService _customerService;
        public CustomerController()
        {
            _customerService = new CustomerService();
        }
        [HttpGet()]
        [Route("Profile")]
        public IHttpActionResult GetCustomerProfile()
        {
            var data = _customerService.GetCustomerProfiles();
            var ret = new GetCustomerProfileRes(ApiStatusEnum.OK, ApiStatusEnum.OK.GetEnumDescription()) { Result = data };
            return Ok(ret);
        }
        [HttpPost]
        [Route("Profile")]
        public IHttpActionResult AddCustomerProfile(CustomerProfile customerProfile)
        {
            var data = _customerService.AddCustomerProfile(customerProfile);
            var ret = new AddCustomerProfileRes(ApiStatusEnum.OK, ApiStatusEnum.OK.GetEnumDescription()) { Result = data };
            return Ok(ret);
        }
        [HttpPut]
        [Route("Profile")]
        public IHttpActionResult UpdateCustomerProfile(CustomerProfile customerProfile)
        {
            var data = _customerService.UpdateCustomerProfile(customerProfile);
            var ret = new UpdateCustomerProfileRes(ApiStatusEnum.OK, ApiStatusEnum.OK.GetEnumDescription()) { Result = data };
            return Ok(ret);
        }
        [HttpDelete]
        [Route("Profile/{id}")]
        public IHttpActionResult DeleteCustomerProfile(Guid id)
        {
            var data = _customerService.DeleteCustomerProfile(id);
            var ret = new DeleteCustomerProfileRes(ApiStatusEnum.OK, ApiStatusEnum.OK.GetEnumDescription()) { Result = data };
            return Ok(ret);
        }

    }
}
