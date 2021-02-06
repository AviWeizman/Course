using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.net_final_project.Models
{
    public class LoginBL
    {
        FactoryDBEntities db = new FactoryDBEntities();

        public user IsAuthenticated(string username, string pwd)
        {
            var result = db.users.Where(x => x.UserName == username && x.Pwd == pwd);
            if (result.Count() != 0)
            {
                return result.First();
            }
            else
            {
                return null;
            }
        }
    }
}
