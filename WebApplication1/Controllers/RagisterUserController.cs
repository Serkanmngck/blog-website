﻿using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [AllowAnonymous]
    public class RagisterUserController : Controller
    {
        private readonly UserManager<AppUser> userManager;

        public RagisterUserController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> Index(UserSingUpViewModel p)
        {
            if(ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {
                    Email = p.Mail,
                    UserName = p.UserName,
                    NameSurname = p.NameSurname

                };
                var result = await userManager.CreateAsync(user, p.Password);

                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }
            return View(p);
        }
    }
}
