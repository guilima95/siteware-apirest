using Siteware.Infra.Attributes;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Siteware.Infra.Exceptions
{
    [HttpStatusCode(400)]
    public class ValidacaoException : Exception
    {
        public ValidacaoException()
        {
        }

        public ValidacaoException(string message) : base(message)
        {
        }

        public ValidacaoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ValidacaoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}