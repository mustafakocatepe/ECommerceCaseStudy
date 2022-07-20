using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Common.Exceptions
{
    public class StateException : Exception
    {
        public int StatusCode { get; set; }

        public StateException()
        { }
        public StateException(int statusCode)
        {
            this.StatusCode = statusCode;
        }
        public StateException(string message) : base(message)
        {
            this.StatusCode = 400;
        }
        public StateException(string message, int statusCode) : base(message)
        {
            this.StatusCode = statusCode;
        }
    }
}
