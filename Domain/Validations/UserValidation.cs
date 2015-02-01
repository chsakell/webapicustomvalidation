using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validations
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.FirstName)
                .Length(10, 50)
                .WithMessage("First name must be between 10 to 50 characters.");

            RuleFor(user => user.FirstName)
                .Must(HasNotDigits)
                .WithMessage("First name cannot contain digits");

            RuleFor(user => user.SexID)
                .NotEqual(0)
                .WithMessage("Please select a Gender");


            RuleFor(user => user.Username).NotNull().WithMessage("Username cannot be null");
            RuleFor(user => user.FirstName).NotNull().WithMessage("First Name cannot be null");

            RuleFor(user => user.Username)
                .Must(NotOffensive)
                .WithMessage("Username has invalid keywords. Try another one.");

            RuleFor(user => user.EmailAddress).EmailAddress();


        }

        private bool HasNotDigits(string name)
        {
            if (!string.IsNullOrEmpty(name))
                return !name.Any(char.IsDigit);
            else return true;
        }

        private bool NotOffensive(string username)
        {
            bool isOffensive = InvalidKeywords.Contains(username.ToLower());
            if (!string.IsNullOrEmpty(username))
                return !isOffensive;
            else return true;
        }

        // Pool from Database..
        private static List<string> InvalidKeywords = new List<string>()
        {
            "thef***word",
            "keyword_02",
            "keyword_03",
            "keyword_04"
        };
    }
}
