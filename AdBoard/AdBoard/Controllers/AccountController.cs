﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdBoard.ViewModels;
using AdBoard.Models;
namespace AdBoard.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        [HttpPost]
        public ActionResult Login(HomeViewModel homeModel)
        {
            User user = UserModel.GetUser(homeModel.Email, Helpers.SecurityHelper.Hash(homeModel.Password));

            if (user != null)
            {
                Helpers.AuthHelper.LogInUser(HttpContext, user.Cookies);

                switch (user.Role.RoleName)
                {
                    case "Admin":
                        return RedirectToAction("Admin", "Admin");
                    case "User":
                        {
                            if (user.IsBlock == false)
                                return RedirectToAction("UserAccount", "User");
                            else
                                return RedirectToAction("Ban", "User");
                        }

                }
            }
            
            return RedirectToAction("Index", "Home");
           
        }

        public ActionResult LogOff()
        {
            Helpers.AuthHelper.LogOffUser(HttpContext);

            return RedirectToAction("Index", "Home");
        }
        public ActionResult GoToAccount()
        {
            return RedirectToAction("UserAccount", "User");
        }

    }
}
