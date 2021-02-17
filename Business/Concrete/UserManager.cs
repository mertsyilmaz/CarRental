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
    public class UserManager : IUserManager
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(User user)
        {
            if (_userDal.Get(u => u.Email == user.Email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            if (!Exists(user.Id))
            {
                return new ErrorResult(Messages.UserNotFound);
            }
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(),Messages.UserListed);
        }

        public IDataResult<User> GetById(int userId)
        {
            if (!Exists(userId))
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == userId),Messages.UserListed);
        }

        public IResult Update(User user)
        {
            if (!Exists( user.Id))
            {
                return new ErrorResult(Messages.UserNotFound);
            }
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserUpdated);
        }
        private bool  Exists(int id)
        {
            return _userDal.Exists(u => u.Id == id);
        }
    }
}
