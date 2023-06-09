﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CarWorkshop.Domain.Interfaces;

using FluentValidation;

namespace CarWorkshop.Application.CarWorkshop;
public class CarWorkshopDtoValidator : AbstractValidator<CarWorkshopDto>
{
    public CarWorkshopDtoValidator(ICarWorkshopRepository repository)
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Add name")
            .MinimumLength(2).WithMessage("Name should have atleast 2 characters")
            .MaximumLength(20).WithMessage("Name should have maximum of 20 characters")
            .Custom((value, context) =>
            {
                var existingCarWorkshop = repository.GetByName(value).Result;
                if(existingCarWorkshop != null)
                {
                    context.AddFailure($"{value} is not unique name for car workshop");
                }
            });
        RuleFor(c => c.Description)
            .NotEmpty().WithMessage("Add description");
        RuleFor(c => c.PhoneNumber)
            .MinimumLength(8)
            .MaximumLength(12);
    }
}
