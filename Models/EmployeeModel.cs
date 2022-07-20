using Adarsh.EmployeeCRM.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Adarsh.EmployeeCRM.Web.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool Status { get; set; }

        public EmployeeViewModel GetViewModel()
        {
            return new EmployeeViewModel()
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                ConfirmEmail = Email,
                ContactNo = ContactNo,
                DepartmentId = DepartmentId,
                Status = Status
            };
        }

    }
}