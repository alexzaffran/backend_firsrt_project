using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//namespace WebApplication1.Models
////{
////    public class ShiftBL
////    {
////        FactoryEntities db = new FactoryEntities();

////        public List<Shift> GetAllShift()
////        {
////            return db.Shift.ToList();
////        }

////        public List<ShiftForEmployee> GetShiftForEmployees()
////        {
////            var result = from emp in db.Employee
////                          join emps in db.EmployeeShift on emp.ID equals emps.EmployeeID
////                          join shft in db.Shift on emps.ShiftID equals shft.ID

////                          orderby shft.ID
////                          select new ShiftForEmployee
////                          {
////                              ShiftId = shft.ID,
////                              EmpId = emps.EmployeeID,
////                              EmpFullName = emp.First_Name + " " + emp.Last_Name,
////                              DateAndTimeShift = shft.Date + " " + shft.Start_Time + ":00-" + shft.End_Time + ":00"

////                          };
////            return result.ToList();
////        }

////        public void AddShift(Shift s)
////        {
////            db.Shift.Add(s);
////            db.SaveChanges();
////        }

////        public void UpdateShift(int id,Shift s)
////        {
////            var s1 = db.Shift.Where(x => x.ID == id).First();

////            s1.Date = s.Date;
////            s1.Start_Time = s.Start_Time;
////            s1.End_Time = s.End_Time;
            

////            db.SaveChanges();
////        }

////        public void DeleteShift(int id)
////        {
////            var p = db.Shift.Where(x => x.ID == id).First();
////            db.Shift.Remove(p);

////            db.SaveChanges();
////        }

////    }
////}
   