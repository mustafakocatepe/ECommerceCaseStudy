using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Common.DTOs.Response
{
    public class ResponseState<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Content { get; set; }


        public static ResponseState<T> Handle(int statusCode, string message, T content)
        {
            return new ResponseState<T> { StatusCode = statusCode, Message = message, Content = content };
        }
    }

    public class ResponseState
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public Object Content { get; set; }

        public ResponseState(int statusCode, string message, Object content = null)
        {
            StatusCode = statusCode;
            Message = message;
            Content = content;
        }  
    }
}
