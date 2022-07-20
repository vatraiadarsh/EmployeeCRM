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
            EmployeeViewModel evm = employee.GetViewModel();

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
                eRepositories.Insert(evm.GetModel());
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
            EmployeeViewModel evm = employee.GetViewModel();
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
                    eRepositories.Update(evm.GetModel());
                    
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
        public ActionResult Delete(int? id)
        {

            return Details(id);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id, Employee employee)
        {
           if(id != null)
            {
                eRepositories.Delete((int)id);
                return RedirectToAction("Index");
            }
           
           return View(employee);
        }
    }
}
