using System.Collections.Generic;
using System.Linq;

//namespace WebApplication1.Models
//{
//    public class EmployeeBL
//    {
//        FactoryEntities db = new FactoryEntities();

//        public List<Employee> GetAllDataEmployee()
//        {
//            return db.Employee.ToList();
//        }

//        public Employee GetEmployee(int id)
//        {
//            return db.Employee.Where(x => x.ID == id).First();
//        }

//        public void AddEmployee(Employee e)
//        {
//            db.Employee.Add(e);
//            db.SaveChanges();
//        }

//        public void UpdateEmployee(int id, Employee emp)
//        {
//            var e = db.Employee.Where(x => x.ID == id).First();

//            e.First_Name = emp.First_Name;
//            e.Last_Name = emp.Last_Name;
//            e.Start_Work_Year = emp.Start_Work_Year;
//            e.DepartmentID = emp.DepartmentID;

//            db.SaveChanges();
//        }

//        public void DeleteEmployee(int id)
//        {
//            var p = db.Employee.Where(x => x.ID == id).First();
//            db.Employee.Remove(p);

//            db.SaveChanges();
//        }

//    }
//}
    