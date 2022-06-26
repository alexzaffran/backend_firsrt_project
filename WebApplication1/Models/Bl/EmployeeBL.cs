using System;
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

        public EmployeeData GetEmployee(int id)
        {
            var employee = db.Employee
                .Where(x => x.ID == id)
                .Join(
                db.Department1,
                emp => emp.DepartmentID,
                department => department.ID,
                (emp, department) =>new EmployeeData
                {
                    Id = emp.ID,
                    FirstName = emp.First_Name,
                    LastName = emp.Last_Name,
                    StartWorkYear = emp.Start_Work_Year,
                    DepartmentId = emp.DepartmentID,
                    DepartmentName = department.Name,
                }
                )
                .FirstOrDefault();

            employee.ShiftList = shiftBl.getAllShiftForOneEmployee(id);

            return employee;
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

            if(updatedEmp == null)
            {
                throw new Exception(string.Format("Employee id: {0} dosen't exist", id));
            }

            if(emp.First_Name!=null)
                updatedEmp.First_Name = emp.First_Name;
            if (emp.Last_Name != null)
                updatedEmp.Last_Name = emp.Last_Name;
            if (emp.Start_Work_Year != null)
                updatedEmp.Start_Work_Year = emp.Start_Work_Year;
            if (emp.DepartmentID != null)
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
