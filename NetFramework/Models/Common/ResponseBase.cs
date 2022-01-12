using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Common
{
    public class ResponseBase
    {
        public ResponseBase() { }
        public ResponseBase(ApiStatusEnum statusCode, string statusDesc)
        {
            StatusCode = statusCode;
            StatusDesc = statusDesc;
        }
        public string ServerTime
        {
            get { return DateTime.Now.ToString("O"); }
        }
        public ApiStatusEnum StatusCode { get; set; }
        public string StatusDesc { get; set; }
    }
}
