using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Domain.Entities;

namespace WebApi.Service.Validators
{
    public class DepartmentValidator: AbstractValidator<Department>
    {
        public DepartmentValidator()
        {
            RuleFor(d => d)
                .NotNull()
                .OnAnyFailure(x =>
                {
                    throw new ArgumentNullException("Can't found the object.");
                });

            RuleFor(d =>d.DepartmentName)
                .NotEmpty().WithMessage("Is necessary to inform the Department Name.")
                .MaximumLength(100).WithMessage("Department Name must be no longer than 100 characters.")
                .NotNull().WithMessage("Is necessary to inform the Departmentname Name.")
                .Must(ValidateDepartmentName).WithMessage("Department name  must be greater than 2");

           
        }


        private bool ValidateDepartmentName(string  DepartmentName)
        {

            if (DepartmentName.Length < 2)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
