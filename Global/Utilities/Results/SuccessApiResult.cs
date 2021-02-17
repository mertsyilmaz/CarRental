using System;
using System.Collections.Generic;
using System.Text;

namespace Global.Utilities.Results
{
    public class SuccessApiResult :ApiResult
    {
        public SuccessApiResult(int statusCode,string message):base(statusCode,true,message)
        {

        }
        public SuccessApiResult(int statusCode):base(statusCode,true)
        {

        }
        public SuccessApiResult(string message):base(200,true,message)
        {

        }
        public SuccessApiResult() : base(200,true)
        {

        }
    }
}
