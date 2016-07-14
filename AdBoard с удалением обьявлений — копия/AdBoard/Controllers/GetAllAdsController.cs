using AdBoard.Model;
using AdBoard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdBoard.Controllers
{
    public class GetAllAdsController : Controller
    {
        //
        // GET: /GetAllAds/

        public ActionResult GetAllAds()
        {
            var homeModel = new HomeModel
            {

                Ads = DataBase.GetAllAds(),
            };

            return View(homeModel);
        }
        public ActionResult Index(string id)
        {
            string searchString = id;
            var ads = from ad in DataBase.GetAllAds() select ad;
            
            if (!String.IsNullOrEmpty(searchString))
            {
                ads = ads.Where(s => s.Title.Contains(searchString));
            }

            return View(ads);
        }

    }
}
