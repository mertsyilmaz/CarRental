using System;
using System.Collections.Generic;
using System.Text;

namespace Global.Utilities.Results
{
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}
