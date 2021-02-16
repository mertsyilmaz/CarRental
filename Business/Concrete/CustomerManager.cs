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
    public class CustomerManager : ICustomerManager
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            if (_customerDal.Get(c => c.CompanyName == customer.CompanyName) != null)
            {
                return new ErrorResult(Messages.CustomerAlreadyExists);
            }
            _customerDal.Add(customer);
            return new SuccessResult();
        }

        public IResult Delete(Customer customer)
        {
            if (!_customerDal.Exists(c => c.Id == customer.Id))
            {
                return new ErrorDataResult<Customer>(Messages.CustomerNotFound);
            }
            _customerDal.Delete(customer);
            return new SuccessResult();
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IDataResult<Customer> GetById(int customerId)
        {
            if (!_customerDal.Exists(c => c.Id == customerId))
            {
                return new ErrorDataResult<Customer>(Messages.CustomerNotFound);
            }
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.Id == customerId));
        }

        public IDataResult<List<Customer>> GetCustemersByUserId(int userId)
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(c => c.UserId == userId));
        }

        public IResult Update(Customer customer)
        {
            if (!_customerDal.Exists(c => c.Id == customer.Id))
            {
                return new ErrorDataResult<Customer>(Messages.CustomerNotFound);
            }
            _customerDal.Update(customer);
            return new SuccessResult();
        }
    }
}
