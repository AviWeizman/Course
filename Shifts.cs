using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.net_final_project.Models
{
    public class Shifts
    {

        public int ID { get; set; }
        public Nullable<System.DateTime> ShiftDate { get; set; }
        public Nullable<int> StartTime { get; set; }
        public Nullable<int> EndTime { get; set; }

    }
}
