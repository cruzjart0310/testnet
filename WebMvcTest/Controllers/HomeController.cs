using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Entidad;
using Negocio;

namespace WebMvcTest
{
    public class HomeController : Controller
    {
        Negocio.User.User instance;
        //
        // GET: /Home/

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Entidad.User.User user)
        {
            if (ModelState.IsValid)
            {
                instance = new Negocio.User.User();
                
                if(instance.authentication(user))
                {
                    Session["user_id"] = "12345678";
                    Session["user_name"] = "user_fx";
                    return RedirectToAction("UserDashboard");
                }
                else
                {
                    ModelState.AddModelError("LOGIN", "Lo sentimos tu cuenta no está disponible.");
                }
            }

            return View(user);
        }

        public ActionResult UserDashboard()
        {
            if (Session["user_id"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}
