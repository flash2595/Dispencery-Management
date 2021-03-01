using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DispenceryManagement.Controllers
{
    [AllowAnonymous]
    public class FAQController : Controller
    {
        // GET: FAQ
        public ActionResult FAQ()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}