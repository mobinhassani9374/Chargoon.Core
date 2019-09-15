using System;
using System.Collections.Generic;
using System.Text;

namespace Chargoon.Messaging
{
    public interface IResponse
    {
        bool IsSuccessful { get; set; }
        string Message { get; set; }
        int ErrorCode { get; set; }
    }
    public class Response : IResponse
    {
        public static Response Error()
        {
            return new Response
            {
                ErrorCode = 0,
                IsSuccessful = false,
                Message = "خطا در برقراری ارتباط با سرور"
            };
        }
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public int ErrorCode { get; set; }
    }
}
