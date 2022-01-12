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
    public class UpdateCustomerProfileRes : ResponseBase
    {
        public UpdateCustomerProfileRes()
        {

        }
        public UpdateCustomerProfileRes(ApiStatusEnum statusCode, string statusDesc) : base(statusCode, statusDesc)
        {

        }
        public CustomerProfile Result { get; set; }
    }
}
