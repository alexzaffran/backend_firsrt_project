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

        public Employee AddEmployee(Employee newEmp)
        {
            var employee = db.Employee.Add(newEmp);
            db.SaveChanges();
            return employee;
        }

        public Employee UpdateEmployee(int id, Employee emp)
        {
            var updatedEmp = db.Employee.Where(x => x.ID == id).FirstOrDefault();

            updatedEmp.First_Name = emp.First_Name;
            updatedEmp.Last_Name = emp.Last_Name;
            updatedEmp.Start_Work_Year = emp.Start_Work_Year;
            updatedEmp.DepartmentID = emp.DepartmentID;

            db.SaveChanges();
            return updatedEmp;
        }

        public Employee DeleteEmployee(int id)
        {
            var deletedEmployee = db.Employee.Where(x => x.ID == id).FirstOrDefault();
            db.Employee.Remove(deletedEmployee);

            db.SaveChanges();
            return deletedEmployee;
        }

    }
}
