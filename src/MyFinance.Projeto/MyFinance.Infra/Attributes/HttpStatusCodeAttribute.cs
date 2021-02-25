using System;
using System.Collections.Generic;
using System.Text;

namespace MyFinance.Infra.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class HttpStatusCodeAttribute : Attribute
    {
        private readonly int statusCode;

        public HttpStatusCodeAttribute(int statusCode)
        {
            this.statusCode = statusCode;
        }
        public int StatusCode { get => statusCode; }
    }
}
