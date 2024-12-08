using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class DoctorValidator:AbstractValidator<Doctor>
    {
        public DoctorValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Please enter doctor's first name!");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Please enter doctor's last name!");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Please enter doctor's email!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Please enter doctor's password!");
        }
    }
}
