using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.DTOLayer.DTOs.AppUserDTOs
{
    public class AppUserRegisterDto
    {
        //[Required(ErrorMessage ="You must have a name!")]
        //[MaxLength(30,ErrorMessage ="First name cannot be more than 30 characters long.")]

        //We can add validations as form of DataAnnotation like above for each prop if we want, however this will breake the S (Single Responsibility Principle) of SOLID principles. So, this will be taken care of in the FluentValidation folder at the BLL layer.

        [Display(Name = "Your First Name")]
        public string Name { get; set; }
        [Display(Name = "Your Second Name")]
        public string Surname { get; set; }
        [Display(Name = "Your E-Mail Address")]
        public string Email { get; set; }
        [Display(Name = "Your Username")]
        public string UserName { get; set; }
        [Display(Name = "Your Password")]
        public string Password { get; set; }
        [Display(Name = "Your Password Again")]
        public string ConfirmedPassword { get; set; }
        
        //public string EmailConfirmed { get; set; }


	}
}

// Name, surname, username, mail, password and confirmedpassword will be just enough for this class.
