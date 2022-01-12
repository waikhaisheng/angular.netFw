using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Enums
{
    public enum ApiStatusEnum
    {
        [Description("Ok")]
        OK = 200,
        [Description("Error")]
        Error = 400
    }
}
