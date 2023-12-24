﻿using EasyCashIdentityProject.DTOLayer.DTOs.CustomerAccountProcessDTOs;
using EasyCashIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
    public class SendMoneyController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SendMoneyController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync(SendMoneyDto sendMoneyDto)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            sendMoneyDto.SenderID = user.Id;
            sendMoneyDto.TransactionDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            
            return View();
        }



    }
}