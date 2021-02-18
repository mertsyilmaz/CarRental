using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Email can not be empty!")
                .EmailAddress().WithMessage("Email is invalid!");

            RuleFor(u => u.FirstName)
                .NotEmpty().WithMessage("Firstname can not be empty!");

            RuleFor(u => u.LastName)
                .NotEmpty().WithMessage("Lastname can not be empty!");

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("Password can not be empty!")
                .Length(6, 12).WithMessage("Password must be between 6 and 12 characters!")
                .Must(CheckPassword).WithMessage("Password is invalid!");
        }

        private bool CheckPassword(string arg)
        {
            var lowercase = new Regex("[a-z]+");
            var uppercase = new Regex("[A-Z]+");
            var digit = new Regex("(\\d)+");
            var symbol = new Regex("(\\W)+");

            return (lowercase.IsMatch(arg) && uppercase.IsMatch(arg) && digit.IsMatch(arg) && symbol.IsMatch(arg));
        }
    }
}
