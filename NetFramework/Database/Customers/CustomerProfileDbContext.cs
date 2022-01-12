using Common.Helpers;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Customers
{
    public class CustomerProfileDbContext : DbContext
    {
        private string _uspGetCustomerProfiles = "uspCustomerProfileList";
        private string _uspAddCustomerProfile = "uspCustomerProfileAdd";
        private string _uspUpdateCustomerProfile = "uspCustomerProfileUpdate";
        private string _uspDeleteCustomerProfile = "uspCustomerProfileDelete";
        public CustomerProfileDbContext(string dbConnectionString) : base (dbConnectionString)
        {

        }

        public List<CustomerProfile> GetCustomerProfiles()
        {
            var customerProfiles = new List<CustomerProfile>();

            using (SqlConnection conn = new SqlConnection(_dbConnectString))
            {
                using (SqlCommand cmd = new SqlCommand(_uspGetCustomerProfiles, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        customerProfiles.Add(new CustomerProfile() 
                        {
                            Id = reader["Id"].ObjectOrDefaultDBNull<Guid>(),
                            Name = reader["Name"].ObjectOrDefaultDBNull<string>(),
                            Phone = reader["Phone"].ObjectOrDefaultDBNull<string>(),
                            Email = reader["Email"].ObjectOrDefaultDBNull<string>(),
                            Address = reader["Address"].ObjectOrDefaultDBNull<string>(),
                            MailingAddress = reader["MailingAddress"].ObjectOrDefaultDBNull<string>(),
                            Created = reader["Created"].ObjectOrDefaultDBNull<DateTime>(),
                            Updated = reader["Updated"].ObjectOrDefaultDBNull<DateTime>()
                        });
                    }
                }
            }
            return customerProfiles;
        }
        public CustomerProfile AddCustomerProfile(CustomerProfile customerProfile)
        {
            var addCustomerProfile = new CustomerProfile();
            addCustomerProfile.Id = customerProfile.Id;
            addCustomerProfile.Name = customerProfile.Name;
            addCustomerProfile.Phone = customerProfile.Phone;
            addCustomerProfile.Email = customerProfile.Email;
            addCustomerProfile.Address = customerProfile.Address;
            addCustomerProfile.MailingAddress = customerProfile.MailingAddress;
            addCustomerProfile.Created = DateTime.Now;
            addCustomerProfile.Updated = DateTime.Now;
            using (SqlConnection conn = new SqlConnection(_dbConnectString))
            {
                using (SqlCommand cmd = new SqlCommand(_uspAddCustomerProfile, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = addCustomerProfile.Id;
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = addCustomerProfile.Name;
                    cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = addCustomerProfile.Phone;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = addCustomerProfile.Email;
                    cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = addCustomerProfile.Address;
                    cmd.Parameters.Add("@MailingAddress", SqlDbType.NVarChar).Value = addCustomerProfile.MailingAddress;
                    cmd.Parameters.Add("@Created", SqlDbType.DateTime).Value = addCustomerProfile.Created;
                    cmd.Parameters.Add("@Updated", SqlDbType.DateTime).Value = addCustomerProfile.Updated;
                    conn.Open();
                    var ret = cmd.ExecuteNonQuery();
                    if (ret > 0)
                        return addCustomerProfile;
                }
            }
            return null;
        }
        public CustomerProfile UpdateCustomerProfile(CustomerProfile customerProfile)
        {
            var addCustomerProfile = new CustomerProfile();
            addCustomerProfile.Id = customerProfile.Id;
            addCustomerProfile.Name = customerProfile.Name;
            addCustomerProfile.Phone = customerProfile.Phone;
            addCustomerProfile.Email = customerProfile.Email;
            addCustomerProfile.Address = customerProfile.Address;
            addCustomerProfile.MailingAddress = customerProfile.MailingAddress;
            addCustomerProfile.Created = DateTime.Now;
            addCustomerProfile.Updated = DateTime.Now;
            using (SqlConnection conn = new SqlConnection(_dbConnectString))
            {
                using (SqlCommand cmd = new SqlCommand(_uspUpdateCustomerProfile, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = addCustomerProfile.Id;
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = addCustomerProfile.Name;
                    cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = addCustomerProfile.Phone;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = addCustomerProfile.Email;
                    cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = addCustomerProfile.Address;
                    cmd.Parameters.Add("@MailingAddress", SqlDbType.NVarChar).Value = addCustomerProfile.MailingAddress;
                    cmd.Parameters.Add("@Updated", SqlDbType.DateTime).Value = addCustomerProfile.Updated;
                    conn.Open();
                    var ret = cmd.ExecuteNonQuery();
                    if (ret > 0)
                        return addCustomerProfile;
                }
            }
            return null;
        }
        public bool DeleteCustomerProfile(Guid id)
        {
            using (SqlConnection conn = new SqlConnection(_dbConnectString))
            {
                using (SqlCommand cmd = new SqlCommand(_uspDeleteCustomerProfile, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = id;
                    conn.Open();
                    var ret = cmd.ExecuteNonQuery();
                    if (ret > 0)
                        return true;
                }
            }
            return false;
        }
    }
}
