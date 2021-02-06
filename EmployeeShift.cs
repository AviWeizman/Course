using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.net_final_project.Models
{
    public class EmplyoeeShift
    {
        public int ID { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public Nullable<int> ShiftID { get; set; }

        public virtual employee employee { get; set; }
        public virtual shift shift { get; set; }
    }
}
