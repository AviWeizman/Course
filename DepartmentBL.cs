using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.net_final_project.Models
{
    public class DepartmentBL
    {
        FactoryDBEntities db = new FactoryDBEntities();



        public HashSet<DepartmentHelper> GetDepartmentsData()
        {
            var result = (from dep in db.departments
                          join emp in db.employees on dep.Manager equals emp.ID
                          join emp2 in db.employees on dep.ID equals emp2.DepID
                          into gj
                          from leftdep in gj.DefaultIfEmpty()
                          select new DepartmentHelper
                          {
                              ID = dep.ID,
                              DepName = dep.DepName,
                              Manager = (int)dep.Manager,
                              EmpId = (leftdep.DepID == null ? "null" : leftdep.DepID.ToString()),
                              EmpName = emp.FirstName + " " + emp.LastName
                          }).ToList();

            HashSet<DepartmentHelper> Ha = new HashSet<DepartmentHelper>(result);
            return Ha;
        }
        public department GetDepartmentData(int id)
        {
            department dep = db.departments.Where(x => x.ID == id).First();
            return dep;
        }
        public void Update(department dep)
        {
            department result = db.departments.Where(x => x.ID == dep.ID).First();
            result.DepName = dep.DepName;
            result.Manager = dep.Manager;
            db.SaveChanges();
        }
        public void Delete(department dep)
        {


            department result = db.departments.Where(x => x.ID == dep.ID).First();
            db.departments.Remove(result);
            db.SaveChanges();
        }
        public void Add(department dep)
        {
            db.departments.Add(dep);
            db.SaveChanges();
        }
        public List<EmployeeData> GetEmpData()
        {
            var result = from emp in db.employees
                         select new EmployeeData
                         {
                             ID = emp.ID,
                             FullName = emp.FirstName + " " + emp.LastName
                         };
            return result.ToList();
        }
    }
}
