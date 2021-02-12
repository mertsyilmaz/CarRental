using System;
using System.Collections.Generic;
using System.Text;

namespace Global.Utilities.Results
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
