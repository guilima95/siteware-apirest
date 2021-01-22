using Siteware.Infra.Attributes;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Siteware.Infra.Exceptions
{
    [HttpStatusCode(400)]
    public class ValidationDomainException : Exception
    {
        public ValidationDomainException()
        {
        }

        public ValidationDomainException(string message) : base(message)
        {
        }

        public ValidationDomainException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ValidationDomainException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}