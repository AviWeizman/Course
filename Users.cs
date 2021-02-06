using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.net_final_project.Models
{
    public class Users
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Pwd { get; set; }
        public int ActionsCounter { get; set; }
        public Nullable<System.DateTime> LastSeen { get; set; }
    }
}
