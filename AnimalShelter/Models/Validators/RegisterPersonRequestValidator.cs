using AnimalShelter.Models;
using AnimalShelter_WebAPI.DTOs.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.Models.Validators
{
    public class RegisterPersonRequestValidator: AbstractValidator<RegisterPersonRequest>
    {

        public RegisterPersonRequestValidator(ShelterDbContext dbContext) 
        {
            RuleFor(x => x.EmailAddress)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password).MinimumLength(6);

         //   RuleFor(x => x.RoleId)
         //       .NotEmpty();


            RuleFor(x => x.EmailAddress)
                .Custom((value, context) =>
                {
                    var emailInUse = dbContext.Person.Any(p => p.EmailAddress == value);

                    if (emailInUse)
                    {
                        context.AddFailure("EmailAddress", "EMAIL_IN_USE");
                    }
                });
        }
        
    }
}
