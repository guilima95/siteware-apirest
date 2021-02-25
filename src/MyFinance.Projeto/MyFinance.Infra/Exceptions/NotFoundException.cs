using MyFinance.Infra.Attributes;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MyFinance.Infra.Exceptions
{
    [HttpStatusCode(404)]
    public class NotFoundException : Exception
    {
        public NotFoundException()
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}