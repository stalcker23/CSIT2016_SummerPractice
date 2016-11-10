using AdBoard.CustomAttribute;
using AdBoard.Models;
using AdBoard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdBoard.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        [PageAuthorize(UserRoles = "Admin")]
        public ActionResult Admin()
        {
            var adminModel = new AdminViewModel();
            {
                adminModel = UserModel.GetAllUsers();
            };

            return View(adminModel);
        }
        public ActionResult GetAllAds()
        {
            var adminModel = new AdViewModel();
            {
                adminModel.Ads = AdModel.GetAllAdsForVerification();
            };

            return View(adminModel);
        }
        public ActionResult AdDelete(int id)
        {

            AdModel.RemoveAd(id);
            return RedirectToAction("GetAllAds","Admin");
        }
        public ActionResult AdOk(int id)
        {
            AdModel.AdVerification(id);
            return RedirectToAction("GetAllAds", "Admin");
        }
        public ActionResult GoToAccount()
        {
            return RedirectToAction("Admin", "Admin");
        }
        public ActionResult BanUser(int id)
        {
            var ads = AdModel.GetAdsByUserId(id);
            foreach(var items in ads)
            {
                UserModel.AdBanUser(items.Id);
            }
            UserModel.BanUnbanUser(id);
            return RedirectToAction("Admin", "Admin");
        }



    }
}
