using EasyCashIdentityProject.DataAccessLayer.Concrete.Context;
using EasyCashIdentityProject.DTOLayer.DTOs.CustomerAccountProcessDTOs;
using EasyCashIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
    public class SendMoneyController : Controller
    {
        //to reach to the user that logged in the system
        private readonly UserManager<AppUser> _userManager;
        private readonly Context _context;

        public SendMoneyController(UserManager<AppUser> userManager, Context context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(SendMoneyDto sendMoneyDto)
        {         
            var receiverAccountNumberID = _context.CustomerAccounts.Where(x => x.CustomerAccountNumber == sendMoneyDto.ReceiverAccountNumber).Select(y => y.CustomerAccountID).FirstOrDefault();

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            sendMoneyDto.SenderID = user.Id;
            sendMoneyDto.TransactionDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            sendMoneyDto.TransactionType = "Havale";
            sendMoneyDto.ReceiverID = receiverAccountNumberID;
             
            return RedirectToAction("Index", "Deneme");
        }



    }
}
