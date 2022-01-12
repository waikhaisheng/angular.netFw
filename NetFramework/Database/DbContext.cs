using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class DbContext
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"]?.ConnectionString;
        protected string _dbConnectString;
        public DbContext()
        {
            _dbConnectString = _connectionString;
        }
        public DbContext(string dbConnectionString)
        {
            _dbConnectString = dbConnectionString;
        }
    }
}
