using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Name).MinimumLength(2).WithMessage("Car name must be at least 2 characters!");
            RuleFor(c => c.Name).NotEmpty().WithMessage("Car name can not be empty!");
            RuleFor(c=> c.DailyPrice).GreaterThan(0).WithMessage("Daily price must be greater than 0!");
        }
    }
}
