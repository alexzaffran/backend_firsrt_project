using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class EmployeeData
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StartWorkYear { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public List<Shift> ShiftList { get; set; }
    }
}