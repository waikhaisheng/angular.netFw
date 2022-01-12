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
    public class DeleteCustomerProfileRes : ResponseBase
    {
        public DeleteCustomerProfileRes()
        {

        }
        public DeleteCustomerProfileRes(ApiStatusEnum statusCode, string statusDesc) : base(statusCode, statusDesc)
        {

        }
        public bool Result { get; set; }
    }
}
