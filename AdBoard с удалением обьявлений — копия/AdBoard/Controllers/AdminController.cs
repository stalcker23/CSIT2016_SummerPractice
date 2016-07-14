using AdBoard.CustomAttribute;
using AdBoard.Model;
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
            var adminModel = new AdminModel();
            {
                adminModel = DataBase.GetAllUsers();
            };

            return View(adminModel);
        }
        public ActionResult GetAllAds()
        {
            var adminModel = new AdModel();
            {
                adminModel.Ads = DataBase.GetAllAdsForVerification();
            };

            return View(adminModel);
        }
        public ActionResult AdDelete(int id)
        {
            var adForDeletingImages = DataBase.GetAdById(id);
            foreach (var image in adForDeletingImages.Images)
            {
                DataBase.RemoveImage(image.Id);
            }
            DataBase.RemoveAd(id);
            return RedirectToAction("GetAllAds","Admin");
        }
        public ActionResult AdOk(int id)
        {
            DataBase.AdVerification(id);
            return RedirectToAction("GetAllAds", "Admin");
        }
        public ActionResult GoToAccount()
        {
            return RedirectToAction("Admin", "Admin");
        }
        public ActionResult BanUser(int id)
        {
            var ads = DataBase.GetAdsByUserId(id);
            foreach(var items in ads)
            {
                DataBase.AdBanUser(items.Id);
            }
            DataBase.BanUnbanUser(id);
            return RedirectToAction("Admin", "Admin");
        }



    }
}
