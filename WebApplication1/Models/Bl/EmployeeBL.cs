using System.Collections.Generic;
using System.Linq;
using System.Web;
using webapplication1.models;

namespace WebApplication1.Models
{
    public class EmployeeBL
    {
        FactoryEntities1 db = new FactoryEntities1();
        ShiftBl shiftBl = new ShiftBl();


        public List<EmployeeData> GetAllDataEmployee()
        {
            var employeesWithdeparment =

                (from emp in db.Employee

                 join department in db.Department1
                 on emp.DepartmentID equals department.ID

                 select new EmployeeData
                 {
                     Id = emp.ID,
                     FirstName = emp.First_Name,
                     LastName = emp.Last_Name,
                     StartWorkYear = emp.Start_Work_Year,
                     DepartmentId = emp.DepartmentID,
                     DepartmentName = department.Name,
                 }).ToList();



            var employeesId = employeesWithdeparment.Select(e => e.Id).ToList();

 

            foreach(var e in employeesWithdeparment)
            {

                e.ShiftList = shiftBl.getAllShiftForOneEmployee(e.Id);
            }


            return employeesWithdeparment;
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
            shiftBl.deleteAllShiftForOneEmployee(id);
            db.Employee.Remove(deletedEmployee);

            db.SaveChanges();
            return deletedEmployee;
        }

        public List<EmployeeData> Search(string input)
        {
            var employees = GetAllDataEmployee();
            var searchedList = employees
                .Where(e => e.LastName
                .ToLower().Contains(input.ToLower()) 
                ||
                 e.FirstName.ToLower().Contains(input.ToLower()) 
                ||
                e.DepartmentName.ToLower().Contains(input.ToLower()))
                .ToList();

            return searchedList;
        }

    }
}
