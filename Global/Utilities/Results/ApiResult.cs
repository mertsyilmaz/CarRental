using System;
using System.Collections.Generic;
using System.Text;

namespace Global.Utilities.Results
{
    public class ApiResult : Result,IApiResult
    {
        public ApiResult(int statusCode,bool success,string message):base(success,message)
        {
            StatusCode = statusCode;
        }

        public ApiResult(int statusCode,bool success):base(success)
        {
            StatusCode = statusCode;
        }

        public int StatusCode { get; }
    }
}
