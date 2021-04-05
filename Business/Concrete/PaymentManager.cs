using Business.Abstract;
using Business.Constants;
using DataAccess.Abstract;
using Entities.Concrete;
using Global.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentManager
    {
        IPaymentDal _paymentDal;

        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        public IResult Add(Payment payment)
        {
            //IResult result = BusinessRules.Run(
            //    BrandNameCheck(brand.Name)
            //    );

            //if (result != null)
            //{
            //    return result;
            //}
            payment.PaymentDate = DateTime.Now;
            _paymentDal.Add(payment);
            return new SuccessResult(Messages.PaymentAdded);
        }

        public IResult Delete(Payment payment)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Payment>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Payment> GetById(int paymentId)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Payment payment)
        {
            throw new NotImplementedException();
        }
    }
}
