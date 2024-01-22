using EasyCashIdentityProject.BusinessLayer.Abstract;
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
        private readonly ICustomerAccountProcessService _customerAccountProcessService;

        public SendMoneyController(UserManager<AppUser> userManager, Context context, ICustomerAccountProcessService customerAccountProcessService)
        {
            _userManager = userManager;
            _context = context;
            _customerAccountProcessService = customerAccountProcessService;
        }

        [HttpGet]
        public IActionResult Index(string currency)
        {
            //when it's first time, default currency is TL
            if (currency == null)
            {
                currency = "TL";
            }
            ViewBag.currency = currency;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(SendMoneyDto sendMoneyDto)
        {         
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var receiverAccountNumberID = _context.CustomerAccounts.Where(x => x.CustomerAccountNumber == sendMoneyDto.ReceiverAccountNumber).Select(y => y.CustomerAccountID).FirstOrDefault();

            //at this point, we need to get the sender's account number id according to the currency type
            //if the currency type is TL, we need to get the TL account number id, same goes for the other currencies
            // and we make sure account of user has the same currency type if not, user must be warned 
            //string currencyType = ViewBag.currency;
            //var senderAccountnumberID = _context.CustomerAccounts.Where(acc => acc.AppUserID == user.Id).Where(user => user.CustomerAccountCurrency == currencyType).Select(acc => acc.CustomerAccountID).FirstOrDefault();
            var senderAccountnumberID = _context.CustomerAccounts.Where(acc => acc.AppUserID == user.Id).Where(user => user.CustomerAccountCurrency == "TL").Select(acc => acc.CustomerAccountID).FirstOrDefault();

            var values = new CustomerAccountProcess()
            {
                TransactionDate = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                TransactionType = "Havale",
                Amount = sendMoneyDto.Amount,
                SenderID = senderAccountnumberID,
                ReceiverID = receiverAccountNumberID,
                Description = sendMoneyDto.Description
            };


            _customerAccountProcessService.TInsert(values);

            return RedirectToAction("Index", "Deneme");
        }




    }
}
