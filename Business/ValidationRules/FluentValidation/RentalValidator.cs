﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator:AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.CarId)
                .NotNull().WithMessage("Car required!");

            RuleFor(r => r.CustomerId)
                .NotNull().WithMessage("Customer required!");

            RuleFor(r => r.RentDate)
                .NotEmpty().WithMessage("Rent date can not be empty!");
        }
    }
}