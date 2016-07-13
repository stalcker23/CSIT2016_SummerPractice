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
            user.RegDate = DateTime.Now; // текущее время
            user.RoleId = 2; // под номером 2 у нас роль User (под номер 1 - Admin)  
            user.Cookies = Guid.NewGuid().ToString(); // cookie для авторизации
            user.IsBlock = false; // аккаунт не заблокирован
            user.Password = Helpers.SecurityHelper.Hash(user.Password);

            DataBase.AddUser(user);

            return RedirectToAction("Index", "Home");
        }
    }
}
