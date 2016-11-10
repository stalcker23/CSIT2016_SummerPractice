using AdBoard.Models;
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
            var homeModel = new HomeViewModel
            {

                Ads = AdModel.GetAllAds(),
            };

            return View(homeModel);
        }
        
        public ActionResult Index(string type, string searchString)
        {

            var types = new List<string>();
            types.Add("Продам");
            types.Add("Куплю");
            ViewBag.type = new SelectList(types);
            var ads = AdModel.Search(type, searchString);
            return View(ads.ToList());
        }

    }
}
