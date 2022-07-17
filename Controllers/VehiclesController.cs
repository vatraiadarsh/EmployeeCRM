using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Adarsh.EmployeeCRM.Web.Models;
using Adarsh.EmployeeCRM.Web.ViewModels;

namespace Adarsh.EmployeeCRM.Web.Controllers
{
    public class VehiclesController : Controller
    {
        // GET: Vehicles
        public ActionResult Index()
        {
            List<Vehicle> vehicles = new List<Vehicle>()
            {
           new Vehicle()
            {
                Id=1,
                VehicleNo="CM07WE",
                AddedDate=DateTime.Now,
                Status=true
            },
             new Vehicle()
             {
                 Id = 2,
                 VehicleNo = "09YG5R",
                 AddedDate = DateTime.Now,
                 Status = false
             },
              new Vehicle()
              {
                  Id = 3,
                  VehicleNo = "GF76RF",
                  AddedDate = DateTime.Now,
                  Status = true
              },
               new Vehicle()
              {
                  Id = 4,
                  VehicleNo = "OUBG54",
                  AddedDate = DateTime.Now,
                  Status = false
              }


        };



            return View(vehicles);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VehicleViewModel vehicle)
        {
            if (ModelState.IsValid)
            {

            }
            return View(vehicle);
        }
    }
}