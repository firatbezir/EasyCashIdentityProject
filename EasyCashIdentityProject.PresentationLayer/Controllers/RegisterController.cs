using EasyCashIdentityProject.DTOLayer.DTOs.AppUserDTOs;
using EasyCashIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserRegisterDto appUserRegisterDto)
        {
            if(ModelState.IsValid) 
            {
                AppUser appUser = new AppUser()
                {
                    UserName = appUserRegisterDto.UserName,
                    Name = appUserRegisterDto.Name,
                    Surname = appUserRegisterDto.Surname,
                    Email = appUserRegisterDto.Email,
                    City = "aaa",
                    District = "bbb",
                    ImageUrl = "ccc"
				};

                // Data adding method for identity (CreateAsync()) is handled at line below
                var result = await _userManager.CreateAsync(appUser, appUserRegisterDto.Password);
                if (result.Succeeded) // if user succesfully created, then handle the mail confirmation tasks which requires to go to the Index action of the ConfirmMailController
                {
                    return RedirectToAction("Index", "ConfirmMail");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View();
        } 
    }
}
//The baxic format in the Identity: (it'll retrun you to retype your password unless your password satisfies the min req.)
/*
 * min 6 chars
 * min 1 small letter
 * min 1 capital letter
 * min 1 symbol
 * min 1 number
 */