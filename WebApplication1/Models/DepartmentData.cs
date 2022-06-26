using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class DepartmentData
    {
        public int DepId { get; set; }
        public string ManagerFullName { get; set; }
        public string DepartmentName { get; set; }
        public List<Employee> Employess { get; set; }

    }
}