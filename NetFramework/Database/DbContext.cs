using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class DbContext
    {
        protected string _dbConnectString;
        public DbContext(string dbConnectionString)
        {
            _dbConnectString = dbConnectionString;
        }
    }
}
