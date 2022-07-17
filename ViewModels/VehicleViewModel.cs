using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Adarsh.EmployeeCRM.Web.ViewModels
{
    public class VehicleViewModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Vehicle No")]
        public string VehicleNo { get; set; }
        public bool Status { get; set; }
    }
}