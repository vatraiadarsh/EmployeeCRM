using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Adarsh.EmployeeCRM.Web.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string VehicleNo { get; set; }

        public DateTime AddedDate { get; set; }

        public bool status { get; set; }

    }
}