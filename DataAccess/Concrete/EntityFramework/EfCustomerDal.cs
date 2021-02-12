﻿using DataAccess.Abstract;
using Entities.Concrete;
using Global.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal:EfEntityRepositoryBase<Customer,CarRentalContext>,ICustomerDal
    {
    }
}
