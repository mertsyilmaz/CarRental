﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator:AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(b => b.Name)
                .NotEmpty().WithMessage("Brand name can not be empty!")
                .MinimumLength(3).WithMessage("min 3");
        }
    }
}
