using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class EmployeeBL
    {
        FactoryEntities1 db = new FactoryEntities1();

        public List<Employee> GetAllDataEmployee()
        {
            return db.Employee.ToList();
        }

        public Employee GetEmployee(int id)
        {
            return db.Employee.Where(x => x.ID == id).FirstOrDefault();
        }

        public void AddEmployee(Employee newEmp)
        {
            db.Employee.Add(newEmp);
            db.SaveChanges();
        }

        public void UpdateEmployee(int id, Employee emp)
        {
            var currentEmp = db.Employee.Where(x => x.ID == id).FirstOrDefault();

            currentEmp.First_Name = emp.First_Name;
            currentEmp.Last_Name = emp.Last_Name;
            currentEmp.Start_Work_Year = emp.Start_Work_Year;
            currentEmp.DepartmentID = emp.DepartmentID;

            db.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            var deletedEmployee = db.Employee.Where(x => x.ID == id).FirstOrDefault();
            db.Employee.Remove(deletedEmployee);

            db.SaveChanges();
        }

    }
}
