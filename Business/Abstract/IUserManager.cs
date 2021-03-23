using Global.Entities.Concrete;
using Global.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserManager
    {
        IDataResult<List<OperationClaim>>  GetClaims(User user);
        IResult Add(User user);
        IDataResult<User> GetByMail(string email);
    }
}
