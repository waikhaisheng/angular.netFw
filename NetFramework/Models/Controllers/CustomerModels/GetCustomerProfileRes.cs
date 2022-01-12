using Models.Common;
using Models.Entities;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Controllers.CustomerModels
{
    public class GetCustomerProfileRes : ResponseBase
    {
        public GetCustomerProfileRes(ApiStatusEnum statusCode, string statusDesc) : base(statusCode, statusDesc)
        {

        }
        public List<CustomerProfile> Result { get; set; }
    }
}
