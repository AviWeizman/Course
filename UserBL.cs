using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.net_final_project.Models
{
    public class UserBL
    {
        public user user;
        private int limitAction = 35;
        FactoryDBEntities db = new FactoryDBEntities();

        public UserBL(user user2)
        {
            user = user2;
        }
        public bool CheckActionCounter(int num)
        {
            CheckDate();
            if (user.ActionsCounter < limitAction)
            {
                user.ActionsCounter = user.ActionsCounter + num;
                HttpContext.Current.Session["ActionCounter"] = user.ActionsCounter;
                UpDateUserData();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CheckDate()
        {
            if (user.LastActionDay == null || (user.LastActionDay != null && user.LastActionDay != DateTime.Today))
            {
                user.ActionsCounter = 0;
                user.LastActionDay = DateTime.Today;
            }
        }
        public void UpDateUserData()
        {
            var result = db.users.Where(x => x.ID == user.ID).First();
            result.ActionsCounter = user.ActionsCounter;
            result.LastActionDay = DateTime.Today;
            db.SaveChanges();
        }

    }
}
