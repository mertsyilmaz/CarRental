using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.CarId)
                .NotNull().WithMessage("Car required!");

            RuleFor(r => r.CustomerId)
                .NotNull().WithMessage("Customer required!");

            RuleFor(r => r.RentDate)
                .NotEmpty().WithMessage("Rent date can not be empty!")
                .Must(LessThanToday).WithMessage("Rent date cannot be less than today's date!");

            RuleFor(r => r.ReturnDate)
                .NotEmpty().WithMessage("Return date can not be empty!")
                .Must(LessThanToday).WithMessage("Return date cannot be less than today's date!")
                .Must( (rentalArgs,returnDate) => LessThanRentDate(rentalArgs.RentDate,returnDate)).WithMessage("Return date cannot be less than rent date!");
        }

        private bool LessThanToday(DateTime arg)
        {
            if (arg.Date < DateTime.Now.Date)
                return false;
            else
                return true;
        }

        private bool LessThanRentDate(DateTime rentDate,DateTime returnDate)
        {
            if (returnDate < rentDate)
                return false;
            else
                return true;
        }
    }
}
