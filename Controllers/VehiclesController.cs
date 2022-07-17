using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Adarsh.EmployeeCRM.Web.Models;

namespace Adarsh.EmployeeCRM.Web.Controllers
{
    public class VehiclesController : Controller
    {
        // GET: Vehicles
        public ActionResult Index()
        {
            Vehicle vehicle = new Vehicle()
            {
                Id = 1,
                VehicleNo = "CMO&YW",
                AddedDate = DateTime.Now,
                status = true

            };
            return View(vehicle);
        }
    }
}