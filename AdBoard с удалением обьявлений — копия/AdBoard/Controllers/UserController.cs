using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdBoard.CustomAttribute;
using AdBoard.ViewModels;
using AdBoard.Model;
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

            var adModel = new AdModel
            {
                Ads = DataBase.GetAdsByUserId(user.Id),
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

            ad.IsPublic = false; //unpublic, waiting verification by admin
            ad.CreateDate = DateTime.Now; // current time
            ad.UserId = user.Id; // user, whom place ad

            DataBase.AddAd(ad);

            // load pictures into server and save link into db
            Helpers.ImageHelper.LoadImages(Request.Files, ad.Id);

            return RedirectToAction("UserAccount", "User");
        }
        [PageAuthorize(UserRoles = "User")]
        public ActionResult RemoveAd(int id)
        {
            User user = Helpers.AuthHelper.GetUser(HttpContext);
            Ad ad = DataBase.GetAdById(id);

            if (ad != null && ad.UserId == user.Id)
            {
                foreach (var item in ad.Images)
                {
                    Helpers.ImageHelper.DeleteFile(item.LargeImage);
                    Helpers.ImageHelper.DeleteFile(item.SmallImage);

                    DataBase.RemoveImage(item);
                }

                DataBase.RemoveAd(ad.Id);
            }

            return RedirectToAction("UserAccount", "User");
        }
        [PageAuthorize(UserRoles = "User")]
        public ActionResult EditAd(int id)
        {
            User user = Helpers.AuthHelper.GetUser(HttpContext);
            Ad ad = DataBase.GetAdById(id);

            if (ad != null && ad.User.Id == user.Id)
            {
                var adModel = new AdModel
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
            DataBase.UpdateAd(ad);

            // load pictures into server and save link into disk
            Helpers.ImageHelper.LoadImages(Request.Files, ad.Id);

            return RedirectToAction("EditAd", "User", new { id = ad.Id });
        }

        [PageAuthorize(UserRoles = "User")]
        public ActionResult RemoveImage(int id)
        {
            User user = Helpers.AuthHelper.GetUser(HttpContext);
            Image image = DataBase.GetImageById(id);

            if (image != null && image.Ad.UserId == user.Id)
            {
                Helpers.ImageHelper.DeleteFile(image.LargeImage);
                Helpers.ImageHelper.DeleteFile(image.SmallImage);


                DataBase.RemoveImage(image);
            }

            return RedirectToAction("EditAd", "User", new { id = image.AdId });
        }

    }

}
