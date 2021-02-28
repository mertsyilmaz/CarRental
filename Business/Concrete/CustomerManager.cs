using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using DataAccess.Abstract;
using Entities.Concrete;
using Global.Aspects.Autofac;
using Global.Utilities.Business;
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
            IResult result = BusinessRules.Run(
                CustomerCompanyNameCheck(customer.CompanyName)
                );

            if (result != null)
            {
                return result;
            }

            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(Customer customer)
        {
            IResult result = BusinessRules.Run(
                CustomerExists(customer.Id)
                );

            if (result != null)
            {
                return result;
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
            IResult result = BusinessRules.Run(
                CustomerExists(customerId)
                );

            if (result != null)
            {
                return new ErrorDataResult<Customer>(result.Message);
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
            IResult result = BusinessRules.Run(
                CustomerExists(customer.Id)
                );

            if (result != null)
            {
                return result;
            }
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
        private IResult CustomerCompanyNameCheck(string companyName)
        {
            if (_customerDal.Get(b => b.CompanyName == companyName) != null)
            {
                return new ErrorResult(Messages.CustomerAlreadyExists);
            }
            return new SuccessResult();
        }

        private IResult CustomerExists(int id)
        {
            if (_customerDal.Exists(b => b.Id == id))
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.CustomerNotFound);
        }
    }
}
