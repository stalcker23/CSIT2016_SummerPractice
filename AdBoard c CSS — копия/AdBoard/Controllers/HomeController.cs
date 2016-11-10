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
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var homeModel = new HomeViewModel
            {
                
                Ads = AdModel.GetAllAds(),
            };

            return View(homeModel);
        }
    }
}
