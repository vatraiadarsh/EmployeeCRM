﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Adarsh.EmployeeCRM.Web.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DisplayName("Confirm Email")]
        [DataType(DataType.EmailAddress)]
        [System.ComponentModel.DataAnnotations.Compare("Email")]
        public string ConfirmEmail { get; set; }

        [Required]
        [DisplayName("Email")]
        public string ContactNo { get; set; }

        [Required]
        [DisplayName("Department")]
        public int DepartmentId { get; set; }

        public IEnumerable<SelectListItem> Departments { get; set; }
       
        public bool Status { get; set; }
    }
}