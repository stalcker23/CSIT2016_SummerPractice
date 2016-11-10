using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdBoard.CustomAttribute;
using AdBoard.ViewModels;
using AdBoard.Models;
namespace AdBoard.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        
        [PageAuthorize(UserRoles = "User")]
        public ActionResult Ban()
        {
            return View();
        }


        public ActionResult UserAccount()
        {
            User user = Helpers.AuthHelper.GetUser(HttpContext);

            var adModel = new AdViewModel
            {
                Ads = AdModel.GetAdsByUserId(user.Id),
            };

            return View(adModel);
        }


        [PageAuthorize(UserRoles = "User")]
        public ActionResult AddAd()
        {
            return View();
        }


        [HttpPost]
        [PageAuthorize(UserRoles = "User")]
        public ActionResult AddAd(Ad ad)
        {
            User user = Helpers.AuthHelper.GetUser(HttpContext);
            AdModel.AddAd(ad,user);

            // load pictures into server and save link into db
            Helpers.ImageHelper.LoadImages(Request.Files, ad.Id);
            return RedirectToAction("UserAccount", "User");
        }


        [PageAuthorize(UserRoles = "User")]
        public ActionResult RemoveAd(int id)
        {
            User user = Helpers.AuthHelper.GetUser(HttpContext);
            Ad ad = AdModel.GetAdById(id);
            AdModel.RemoveAd(ad, user);

            return RedirectToAction("UserAccount", "User");
        }


        [PageAuthorize(UserRoles = "User")]
        public ActionResult EditAd(int id)
        {
            User user = Helpers.AuthHelper.GetUser(HttpContext);
            Ad ad = AdModel.GetAdById(id);
            if (ad != null && ad.User.Id == user.Id)
            {
                var adModel = new AdViewModel
                {
                    Id = ad.Id,
                    Text = ad.Text,
                    Title = ad.Title,
                    AdTypeId = ad.AdTypeId,
                    Images = ad.Images.ToArray(),
                };

                return View(adModel);
            }

            return RedirectToAction("UserAccount", "User");
        }


        [HttpPost]
        [PageAuthorize(UserRoles = "User")]
        public ActionResult EditAd(Ad ad)
        {
            AdModel.UpdateAd(ad);

            // load pictures into server and save link into disk
            Helpers.ImageHelper.LoadImages(Request.Files, ad.Id);

            return RedirectToAction("EditAd", "User", new { id = ad.Id });
        }


        [PageAuthorize(UserRoles = "User")]
        public ActionResult RemoveImage(int id)
        {
            User user = Helpers.AuthHelper.GetUser(HttpContext);
            Image image = ImageModel.GetImageById(id);
            ImageModel.RemoveImage(image, user);
            return RedirectToAction("EditAd", "User", new { id = image.AdId });
        }

    }

}
