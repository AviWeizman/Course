using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.net_final_project.Models
{
    public class department
    {
        public int ID { get; set; }
        public string DepName { get; set; }
        public Nullable<int> Manager { get; set; }
    }
}
