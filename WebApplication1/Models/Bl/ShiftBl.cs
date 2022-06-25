using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1;
using WebApplication1.Models;

namespace webapplication1.models
{
public class ShiftBl
{
        FactoryEntities1 db = new FactoryEntities1();


    public List<Shift> getAllShiftForOneEmployee(int employeeId)
     {
            var shiftIdRelevant = db.EmployeeShift
                .Where(es => es.EmployeeID == employeeId)
                .Select(es => es.ShiftID);

            var shifts =  db.Shift
                    .Where(s => shiftIdRelevant.Any(sh => sh == s.ID))
                    .ToList();

            return shifts;
     }



    public List<Shift> deleteAllShiftForOneEmployee(int employeeId)
    {
        var shiftIdRelevant = db.EmployeeShift
            .Where(es => es.EmployeeID == employeeId)
            .Select(es => es.ShiftID);

        var shifts = db.Shift
                .Where(s => shiftIdRelevant.Any(sh => sh == s.ID))
                .ToList();

            db.Shift.RemoveRange(shifts);
            db.SaveChanges();

            return shifts;
    }

    public List<ShiftData> getAllShiftWithEmlpoyeeData()
    {

            var shifts = db.Shift.ToList();

            var shiftDataList = new List<ShiftData>();

            foreach (var shift in shifts)
            {
                var employeeIds = db.EmployeeShift
                .Where(e => shift.ID == e.ShiftID)
                .Select(e => e.EmployeeID)
                .ToList();

                var employees = db.Employee
                    .Where(e => employeeIds.Any(emp => emp == e.ID))
                    .ToList();

                var shiftData = new ShiftData();
                shiftData.ID = shift.ID;
                shiftData.Date = shift.Date;
                shiftData.Start_Time = shift.Start_Time;
                shiftData.End_Time = shift.End_Time;
                shiftData.Employees = employees;
                shiftDataList.Add(shiftData);

            }


        return shiftDataList;
    }

        public Shift addshift(Shift s, int employeeId)
    {
        var shiftSaved = db.Shift.Add(s);
        db.SaveChanges();

        var employeeShift = new EmployeeShift();
        employeeShift.EmployeeID = employeeId;
        employeeShift.ShiftID = shiftSaved.ID;

        db.SaveChanges();

        return shiftSaved;
    }

        //public List<Shift> getallshift()
        //{
        //    return db.Shift.tolist();
        //}

        //public List<shiftforemployee> getshiftforemployees()
        //{
        //    var result = from emp in db.employee
        //                 join emps in db.employeeshift on emp.id equals emps.employeeid
        //                 join shft in db.shift on emps.shiftid equals shft.id

        //                 orderby shft.id
        //                 select new shiftforemployee
        //                 {
        //                     shiftid = shft.id,
        //                     empid = emps.employeeid,
        //                     empfullname = emp.first_name + " " + emp.last_name,
        //                     dateandtimeshift = shft.date + " " + shft.start_time + ":00-" + shft.end_time + ":00"

        //                 };
        //    return result.tolist();
        //}



        //public void updateshift(int id, shift s)
        //{
        //    var s1 = db.shift.where(x => x.id == id).first();

        //    s1.date = s.date;
        //    s1.start_time = s.start_time;
        //    s1.end_time = s.end_time;


        //    db.savechanges();
        //}

        //public void deleteshift(int id)
        //{
        //    var p = db.shift.where(x => x.id == id).first();
        //    db.shift.remove(p);

        //    db.savechanges();
        //}

    }
}
