using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdBoard.Model;
namespace AdBoard.Controllers
{
    public class RegistrationController : Controller
    {
        //
        // GET: /Registration/

        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(User user)
        {
            user.RegDate = DateTime.Now; // current time
            user.RoleId = 2; // number 2 - role User (number 1 - Admin)  
            user.Cookies = Guid.NewGuid().ToString(); // cookie for auth
            user.IsBlock = false; // banned acc
            user.Password = Helpers.SecurityHelper.Hash(user.Password);

            DataBase.AddUser(user);

            return RedirectToAction("Index", "Home");
        }
    }
}
