using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public static class DbHelper
    {
        public static T ObjectOrDefaultDBNull<T>(this object obj)
        {
            if (obj == System.DBNull.Value)
                return default(T);

            return (T)obj;
        }
    }
}
