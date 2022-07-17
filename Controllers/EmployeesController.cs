using Adarsh.EmployeeCRM.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Adarsh.EmployeeCRM.Web.Repositories;

namespace Adarsh.EmployeeCRM.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private IDepartmentRepositories drepositories = new DepartmentRepositories();
        private IEmployeeRepositories erepositories = new EmployeeRepositories();


        // GET: Employee
        public ActionResult Index()
        {
            return View(erepositories.GetAll());
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
            evm.Departments = from dept in drepositories.GetAll()
                              select new SelectListItem
                              {
                                  Text = dept.Name,
                                  Value = dept.Id.ToString()
                              };


            return View(evm);
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(EmployeeViewModel evm)
        {
            if (ModelState.IsValid)
            {
                erepositories.Insert(new Models.Employee()
                {
                    FirstName = evm.FirstName,
                    LastName = evm.LastName,
                    Email = evm.Email,
                    ContactNo = evm.ContactNo,
                    DepartmentId = evm.DepartmentId,
                    Status = evm.Status,

                });
                return RedirectToAction("Index");

            }
            evm.Departments = from dept in drepositories.GetAll()
                                              select new SelectListItem
                                              {
                                                  Text = dept.Name,
                                                  Value = dept.Id.ToString()
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
