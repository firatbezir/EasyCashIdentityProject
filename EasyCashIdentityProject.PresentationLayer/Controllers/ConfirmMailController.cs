﻿using EasyCashIdentityProject.EntityLayer.Concrete;
using EasyCashIdentityProject.PresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
	public class ConfirmMailController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

        public ConfirmMailController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
		public IActionResult Index()
		{
			var value = TempData["Mail"];            
            ViewBag.v = value;
			return View();
		}

		[HttpPost]
        public async Task<IActionResult> Index(ConfirmMailViewModel confirmMailViewModel)
        {            
            var user = await _userManager.FindByEmailAsync(confirmMailViewModel.Mail);
            if(user.ConfirmationCode == confirmMailViewModel.ConfirmationCode)
            {
                return RedirectToAction("Index", "MyProfile");
                // This muust be Login-Index
                // Email confirmed need to be true!
            }
            return View();
        }

    }
}
// At next step: at  LoginPage
//Username - password must match
//Email must be confirmed