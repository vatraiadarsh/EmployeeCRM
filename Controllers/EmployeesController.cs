using Adarsh.EmployeeCRM.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Adarsh.EmployeeCRM.Web.Repositories;
using Adarsh.EmployeeCRM.Web.Models;
using System.Net.Mail;
using System.Net;
using Adarsh.EmployeeCRM.Web.Helpers;

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
                Employee employee = evm.GetModel();
                if (evm.Picture.FileName != "")
                {
                    if (ImageHelper.IsValidFile(evm.Picture.ContentType)){
                        string fileName = Guid.NewGuid().ToString() + "." + ImageHelper.GetFileExtension(evm.Picture.ContentType);
                        evm.Picture.SaveAs(Server.MapPath("~/Uploads/" + fileName));
                        employee.Picture = fileName;
                    }
                }
                eRepositories.Insert(employee);
                if (evm.Notify)
                {
                    SendNotification(evm);
                }
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

        public void SendNotification(EmployeeViewModel evm)
        {
            MailMessage mailMessage = new MailMessage();

            mailMessage.From = new MailAddress("email address");
            mailMessage.To.Add(new MailAddress(evm.Email));

            mailMessage.Subject = evm.FirstName + evm.LastName + "Your account has been created";          
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = "<h2> Dear" + evm.FirstName + " " + evm.LastName +" </h2> <br/> Your account has been created and you are in -- department";

            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.Credentials = new NetworkCredential("email address","password");
            client.EnableSsl = true;
            client.Send(mailMessage);

        }

    }



}
