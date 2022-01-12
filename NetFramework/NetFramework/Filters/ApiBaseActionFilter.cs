using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Models.Enums;
using Models.Common;

namespace NetFramework.Filters
{
    public class ApiBaseActionFilter : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(HttpActionContext filterContext)
        {
            if (!filterContext.ModelState.IsValid)
            {
                var errorRes = new ResponseBase();
                IEnumerable<string> modelStateErrors = from state in filterContext.ModelState.Values
                                                       from error in state.Errors
                                                       where !string.IsNullOrEmpty(error.ErrorMessage)
                                                       select error.ErrorMessage;
                string errorStr = JsonConvert.SerializeObject(modelStateErrors);
                IEnumerable<string> modelStateException = from state in filterContext.ModelState.Values
                                                          from error in state.Errors
                                                          where null != error.Exception
                                                          select error.Exception.Message;
                string errorEx = JsonConvert.SerializeObject(modelStateException);
                try
                {
                    errorRes = JsonConvert.DeserializeObject<ResponseBase>(errorStr);
                    if (errorRes == null && errorEx != null)
                    {
                        errorRes = new ResponseBase(ApiStatusEnum.Error, errorEx);
                    }
                }
                catch (Exception)
                {
                    if (errorEx != null)
                    {
                        errorStr = $"[{errorStr}][{errorEx}]";
                    }
                    errorRes = new ResponseBase(ApiStatusEnum.Error, errorStr);
                }
                filterContext.Response = filterContext.Request.CreateResponse(
                    HttpStatusCode.BadRequest,
                    errorRes,
                    filterContext.ControllerContext?.Configuration?.Formatters?.JsonFormatter);
                return;
            }
            base.OnActionExecuting(filterContext);
        }
        public override void OnActionExecuted(HttpActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }
    }
}