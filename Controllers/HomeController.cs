using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Adarsh.EmployeeCRM.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        /*[HttpPost]
        public string  Index(HttpPostedFileBase picture)
        {
            Response.Write(picture.FileName);
            picture.SaveAs(Server.MapPath("~/Uploads/" + picture.FileName));
            Response.End();
            return "";
        }
        */
    }
}