using Adarsh.EmployeeCRM.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Adarsh.EmployeeCRM.Web.Repositories;
using Adarsh.EmployeeCRM.Web.Models;

namespace Adarsh.EmployeeCRM.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private IDepartmentRepositories dRepositories = new DepartmentRepositories();
        private IEmployeeRepositories eRepositories = new EmployeeRepositories();


        // GET: Employee
        public ActionResult Index()
        {
            return View(eRepositories.GetAll());
        }

        // GET: Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            Employee employee = eRepositories.GetById((int)id);
            if (employee == null)
            {
                return RedirectToAction("Index");


            }
            EmployeeViewModel evm = new EmployeeViewModel()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                ConfirmEmail = employee.Email,
                ContactNo = employee.ContactNo,
                DepartmentId = employee.DepartmentId,
                Status = employee.Status
            };

            evm.Departments = GetDepartmentList();


            return View(evm);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            EmployeeViewModel evm = new EmployeeViewModel();
            evm.Departments = GetDepartmentList();

            return View(evm);
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeViewModel evm)
        {
            if (ModelState.IsValid)
            {
                eRepositories.Insert(new Models.Employee()
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
            evm.Departments = GetDepartmentList();



            return View(evm);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int? id)
        {

            if(id == null)
            {
                return RedirectToAction("Index");
            }

            Employee employee = eRepositories.GetById((int)id);
            if(employee == null)
            {
                return RedirectToAction("Index");
               

            }
            EmployeeViewModel evm = new EmployeeViewModel()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                ConfirmEmail = employee.Email,
                ContactNo = employee.ContactNo,
                DepartmentId = employee.DepartmentId,
                Status = employee.Status
            };

            evm.Departments = GetDepartmentList();


            return View(evm);
        }


        private IEnumerable<SelectListItem> GetDepartmentList()
        {
            return from dept in dRepositories.GetAll()
                   select new SelectListItem
                   {
                       Text = dept.Name,
                       Value = dept.Id.ToString()
                   };
        }


        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,  EmployeeViewModel evm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    eRepositories.Update(new Models.Employee()
                    {
                        Id = evm.Id,
                        FirstName = evm.FirstName,
                        LastName = evm.LastName,
                        Email = evm.Email,
                        ContactNo = evm.ContactNo,
                        DepartmentId = evm.DepartmentId,
                        Status = evm.Status,

                    });
                    return RedirectToAction("Index");

                }
                evm.Departments = GetDepartmentList();



                return View(evm);

                
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
