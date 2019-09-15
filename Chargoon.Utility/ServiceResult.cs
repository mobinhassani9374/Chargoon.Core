using System;
using System.Collections.Generic;
using System.Text;

namespace Chargoon.Utility
{
    public class ServiceResult
    {
        public string Message { get; set; }

        public bool IsSuccessed { get; set; }

        public static ServiceResult Okay()
        {
            return new ServiceResult() {  IsSuccessed=true, Message="عملیات با موفقیت انجام شد"};
        }

        public static ServiceResult Error()
        {
            return new ServiceResult() { IsSuccessed = false, Message = "عملیات با خطا مواجه شد مجددا تلاش کنید" };
        }

        public static ServiceResult Okay(string message)
        {
            return new ServiceResult() { IsSuccessed = true, Message = message };
        }

        public static ServiceResult Error(string message)
        {
            return new ServiceResult() { IsSuccessed = false, Message = message };
        }
    }
}
