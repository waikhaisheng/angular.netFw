using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Cors;
using System.Web.Http.Cors;

namespace NetFramework.Filters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class ApiCorsPolicyAttribute : Attribute, ICorsPolicyProvider
    {
        private CorsPolicy _policy;
        public ApiCorsPolicyAttribute()
        {
            _policy = new CorsPolicy
            {
                AllowAnyMethod = true,
                AllowAnyHeader = true
            };

            _policy.Origins.Add("http://localhost:4200");
        }
        public Task<CorsPolicy> GetCorsPolicyAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_policy);
        }
    }
}