using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using DataAccess.Abstract;
using Entities.Concrete;
using Global.Aspects.Autofac;
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

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            if (_customerDal.Get(c => c.CompanyName == customer.CompanyName) != null)
            {
                return new ErrorResult(Messages.CustomerAlreadyExists);
            }

            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(Customer customer)
        {
            if (!Exists(customer.Id))
            {
                return new ErrorDataResult<Customer>(Messages.CustomerNotFound);
            }
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(),Messages.CustomerListed);
        }

        public IDataResult<Customer> GetById(int customerId)
        {
            if (!Exists(customerId))
            {
                return new ErrorDataResult<Customer>(Messages.CustomerNotFound);
            }
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.Id == customerId),Messages.CustomerListed);
        }

        public IDataResult<List<Customer>> GetCustemersByUserId(int userId)
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(c => c.UserId == userId),Messages.CustomerListed);
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(Customer customer)
        {
            if (!Exists(customer.Id))
            {
                return new ErrorDataResult<Customer>(Messages.CustomerNotFound);
            }
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
        private bool Exists(int id)
        {
            return _customerDal.Exists(c => c.Id == id);
        }
    }
}
