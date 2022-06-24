using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace WebApplication1.Controllers
{
    public class EmployeeController : ApiController
    {
        static EmployeeBL empBL = new EmployeeBL();
        // GET api/<controller>
        public List<Employee> Get()
        {
            try
            {
                Trace.WriteLine(String.Format("EmployeeController - Get"));
                return empBL.GetAllDataEmployee();

            }
            catch (Exception e)
            {
                Trace.TraceError(String.Format("LoginController - Get - Error: %s", e.Message));
                throw new Exception(e.Message);
            }
        }

        // GET api/<controller>/5
        public Employee Get(int id)
        {
            return empBL.GetEmployee(id);
        }

        // POST api/<controller>
        public string Post(Employee emp)
        {
            empBL.AddEmployee(emp);
            return "Created!";
        
        }

        // PUT api/<controller>/5
        public string Put(int id, Employee emp)
        {
            empBL.UpdateEmployee(id, emp);
            return "Updated!";
        }

        // DELETE api/<controller>/5
       public string Delete(int id)
        {
            empBL.DeleteEmployee(id);
            return "Deleted";

        }
    }
}