using EasyCashIdentityProject.BusinessLayer.Abstract;
using EasyCashIdentityProject.DataAccessLayer.Abstract;
using EasyCashIdentityProject.DataAccessLayer.Concrete.Context;
using EasyCashIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
    public class UserRecentProcessesController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICustomerAccountProcessService _costumerAccountProcessService;
        private readonly Context _context;

        public UserRecentProcessesController(UserManager<AppUser> userManager, ICustomerAccountProcessService costumerAccountProcessService, Context context)
        {
            _userManager = userManager;
            _costumerAccountProcessService = costumerAccountProcessService;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            //we need to check the user whether he/she is a Money Sender or Money Receiver
            //if the authenticated user is a Money Sender or Receiver, we need to show the recent money sending processes
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            int UserId = _context.CustomerAccounts.Where(x => x.AppUserID == user.Id || x.CustomerAccountCurrency == "TL").Select(y => y.CustomerAccountID).FirstOrDefault();
            var reentProcesses = _costumerAccountProcessService.TGetRecentProcessesBySenderId(UserId);

            return View(reentProcesses);
        }
    }
}
