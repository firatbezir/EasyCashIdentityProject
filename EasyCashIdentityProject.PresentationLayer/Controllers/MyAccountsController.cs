using EasyCashIdentityProject.DTOLayer.DTOs.AppUserDTOs;
using EasyCashIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
    [Authorize]  // this attribute puts a condition of authorization to reach that page.
    public class MyAccountsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public MyAccountsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userInformations = await _userManager.FindByNameAsync(User.Identity.Name);  // by User.Identity.Name; the user who logged in to the system will be brought.
            AppUserEditProfileDto appUEPDto = new AppUserEditProfileDto();
            appUEPDto.Name = userInformations.Name;
            appUEPDto.LastName = userInformations.Surname;
            appUEPDto.PhoneNumber = userInformations.PhoneNumber;
            appUEPDto.Email = userInformations.Email;
            appUEPDto.City = userInformations.City;
            appUEPDto.District = userInformations.District; 
            appUEPDto.ImageUrl = userInformations.ImageUrl;
            return View(appUEPDto);
        }
    }
}
