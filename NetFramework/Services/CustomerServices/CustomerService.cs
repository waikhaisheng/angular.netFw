using Common.Utils;
using Database.Customers;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CustomerServices
{
    public class CustomerService
    {
        private CustomerProfileDbContext _customerProfileDbContext;
        public CustomerService()
        {
            _customerProfileDbContext = new CustomerProfileDbContext();
        }
        public List<CustomerProfile> GetCustomerProfiles()
        {
            var cps = _customerProfileDbContext.GetCustomerProfiles();
            return cps;
        }
        public CustomerProfile AddCustomerProfile(CustomerProfile customerProfile)
        {
            if (customerProfile == null)
                throw new ArgumentNullException();
            if (!ValidateUtil.ValidateEmail(customerProfile.Email))
                throw new ArgumentException("Email in valid.");
            if (!ValidateUtil.ValidatePhone(customerProfile.Phone))
                throw new ArgumentException("Phone in valid.");

            var cp = _customerProfileDbContext.AddCustomerProfile(customerProfile);
            return cp;
        }
        public CustomerProfile UpdateCustomerProfile(CustomerProfile customerProfile)
        {
            if (customerProfile == null)
                throw new ArgumentNullException();
            if (!ValidateUtil.ValidateEmail(customerProfile.Email))
                throw new ArgumentException("Email in valid.");
            if (!ValidateUtil.ValidatePhone(customerProfile.Phone))
                throw new ArgumentException("Phone in valid.");

            var cp = _customerProfileDbContext.UpdateCustomerProfile(customerProfile);
            return cp;
        }
        public bool DeleteCustomerProfile(Guid id)
        {
            var cp = _customerProfileDbContext.DeleteCustomerProfile(id);
            return cp;
        }
    }
}
