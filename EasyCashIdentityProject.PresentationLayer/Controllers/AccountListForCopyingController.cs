using EasyCashIdentityProject.BusinessLayer.Abstract;
using EasyCashIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
    public class AccountListForCopyingController : Controller
    {
        private readonly ICustomerAccountService _accountService;
        private readonly UserManager<AppUser> _userManager;

        public AccountListForCopyingController(ICustomerAccountService accountService, UserManager<AppUser> userManager)
        {
            _accountService = accountService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var accountList = _accountService.TGetCustomerAccountsList(user.Id);
            return View(accountList);
        }
    }
}
