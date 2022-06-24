using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//namespace WebApplication1.Models
//{
//    public class DepartmentBL
//    {
//        FactoryEntities db = new FactoryEntities();

//        public List<DepWithEmp> GetAllData()
//        {
//            var result = from dep in db.Department1
//                         join emp in db.Employee
//                         on dep.Manager equals emp.ID
//                         select new DepWithEmp
//                         {
//                             ID = dep.ID,
//                             Name = dep.Name,
//                             Manager = dep.Manager,
//                             First_Name = emp.First_Name,
//                             Last_Name = emp.Last_Name,
//                             DepartmentID = emp.DepartmentID,
//                         };

//            return result.ToList();
//        }

//        public DepWithEmp GetDepartment(int id)
//        {
//            var result = from department in db.Department1
//                         join emp in db.Employee on department.Manager equals emp.ID
//                         select new DepWithEmp
//                         {
//                             ID = department.ID,
//                             Name = department.Name,
//                             Manager = department.Manager,
//                             First_Name = emp.First_Name,
//                             Last_Name = emp.Last_Name,
//                             DepartmentID = emp.DepartmentID,
//                         };

//            return result.Where(x => x.ID == id).First();
//        }

//        public void AddDepartment(Department1 dep)
//        {
//            db.Department1.Add(dep);
//            db.SaveChanges();
//        }

//        public void EditDepartement(int id, Department1 dep)
//        {
//            var d = db.Department1.Where(x => x.ID == id).First();

//            d.Name = dep.Name;
//            d.Manager = dep.Manager;

//            db.SaveChanges();
//        }

//        public void DeleteDepartment(int id)
//        {
//            var d = db.Department1.Where(x => x.ID == id).First();
//            db.Department1.Remove(d);

//            db.SaveChanges();
//        }
//    }
//}