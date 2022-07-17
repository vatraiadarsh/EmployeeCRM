using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Adarsh.EmployeeCRM.Web.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public bool Status { get; set; }
    }
}