using Entities.Concrete;
using Global.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPaymentManager
    {
        IDataResult<List<Payment>> GetAll();
        IDataResult<Payment> GetById(int paymentId);
        IResult Add(Payment payment);
        IResult Delete(Payment payment);
        IResult Update(Payment payment);
    }
}
