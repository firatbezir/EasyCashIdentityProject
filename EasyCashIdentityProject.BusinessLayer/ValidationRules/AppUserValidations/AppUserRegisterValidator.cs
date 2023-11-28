using EasyCashIdentityProject.DTOLayer;
using EasyCashIdentityProject.DTOLayer.DTOs.AppUserDTOs;
using FluentValidation;
using Microsoft.AspNetCore.Rewrite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.BusinessLayer.ValidationRules.AppUserValidations
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(dto => dto.Name).NotEmpty().WithMessage("This field cannot be skipped!");
            RuleFor(dto => dto.Name).MaximumLength(30).WithMessage("Name cannot be more than 30 characters long!");
            RuleFor(dto => dto.Name).MinimumLength(2).WithMessage("Name must be at least 3 characters long!");
            
            
            RuleFor(dto => dto.Name).NotEmpty().WithMessage("This field cannot be skipped!");
            RuleFor(dto => dto.Surname).MinimumLength(2).WithMessage("Surname must be at least 3 characters long!");

            RuleFor(dto => dto.UserName).NotEmpty().WithMessage("This field cannot be skipped!");

            RuleFor(dto => dto.Email).NotEmpty().WithMessage("This field cannot be skipped!");
            RuleFor(dto => dto.Email).EmailAddress().WithMessage("Please enter a valid e-mail address!");

            RuleFor(dto => dto.Password).NotEmpty().WithMessage("This field cannot be skipped!");

            RuleFor(dto => dto.ConfirmedPassword).NotEmpty().WithMessage("This field cannot be skipped!");
            RuleFor(dto => dto.ConfirmedPassword).Equal(y => y.Email).WithMessage("Passwords does not match!");
        }
    }
}

// RuleFor method is called in the constructor method, so why?
/*
 1. It helps to controll all the validation rules from one point.
 2. As it is constructor, it intagrates all it have to its class. 
 3. And, obviously cleaner design.
 */
