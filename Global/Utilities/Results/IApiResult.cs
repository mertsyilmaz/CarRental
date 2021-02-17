using System;
using System.Collections.Generic;
using System.Text;

namespace Global.Utilities.Results
{
    public interface IApiResult : IResult
    {
        int StatusCode { get; }
    }
}
