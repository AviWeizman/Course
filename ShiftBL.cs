using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.net_final_project.Models
{
    public class ShiftBL
    {
        FactoryDBEntities db = new FactoryDBEntities();
        public List<ShiftAndEmp> GetShiftData()
        {
            var result = (from emp in db.employees
                          join
                          emp_sh in db.EmployeeShifts on
                          emp.ID equals emp_sh.EmployeeID
                          join shifts in db.shifts on
                          emp_sh.ShiftID equals shifts.ID
                          select new ShiftAndEmp
                          {
                              ID = emp.ID,
                              FullName = emp.FirstName + " " + emp.LastName,
                              ShiftDate = (System.DateTime)shifts.ShiftDate,
                              StartTime = (int)shifts.StartTime,
                              EndTime = (int)shifts.EndTime,
                          }).ToList();

            return result;
        }
        public void Add(shift sh)
        {
            db.shifts.Add(sh);
            db.SaveChanges();
        }
    }
}
