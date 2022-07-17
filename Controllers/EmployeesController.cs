using Adarsh.EmployeeCRM.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Adarsh.EmployeeCRM.Web.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            EmployeeViewModel evm = new EmployeeViewModel();
            evm.Departments = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "Accounting",
                    Value = "1"
                },
                new SelectListItem()
                {
                    Text="Administration",
                    Value="2"
                },

            };
            return View(evm);
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(EmployeeViewModel evm)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");

            }
            evm.Departments = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "Accounting",
                    Value = "1"
                },
                new SelectListItem()
                {
                    Text="Administration",
                    Value="2"
                },

            };
            return View(evm);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
