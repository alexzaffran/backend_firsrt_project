using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Web.Http.Cors;

namespace WebApplication1.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmployeeController : ApiController
    {
        static EmployeeBL empBL = new EmployeeBL();
        // GET api/<controller>
        [HttpGet]
        [ActionName("GetAllEmployees")]
        public IHttpActionResult Get()
        {
            try
            {
                Trace.WriteLine(String.Format("EmployeeController - Get"));
                return Ok(empBL.GetAllDataEmployee());

            }
            catch (Exception e)
            {
                Trace.TraceError(String.Format("LoginController - Get - Error: %s", e.Message));
                return BadRequest(e.Message);
            }
        }

        // GET api/<controller>/5
        [HttpGet]
        [ActionName("GetEmployee")]
        public IHttpActionResult GetEmployee(int id)
        {
            try
            {
                Trace.WriteLine(String.Format("EmployeeController - GetEmployee"));
                EmployeeData result = empBL.GetEmployee(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                Trace.TraceError(String.Format("LoginController - AddUser - Error: %s", e.Message));
                return BadRequest(String.Format("{0}", e.Message));

            }
        }


        // POST api/<controller>
        [HttpPost]
        [ActionName("AddEmployee")]
        public IHttpActionResult AddEmployee(Employee emp)
        {
            try
            {
                Trace.WriteLine(String.Format("EmployeeController - AddEmployee"));
                Employee result = empBL.AddEmployee(emp);
                return Ok(result);
            }
            catch (Exception e)
            {
                Trace.TraceError(String.Format("LoginController - AddUser - Error: %s", e.Message));
                return BadRequest(String.Format("{0}", e.Message));

            }
        }

        // PUT api/<controller>/5
        
        [HttpPut]
        [ActionName("UpdateEmployee")]
        public IHttpActionResult UpdateEmployee(int id, Employee emp)
        {
            try
            {
                Trace.WriteLine(String.Format("EmployeeController - UpdateEmployee"));
                Employee result = empBL.UpdateEmployee(id,emp);
                return Ok(result);
            }
            catch (Exception e)
            {
                Trace.TraceError(String.Format("EmployeeController - UpdateEmployee - Error: %s", e.Message));
                return BadRequest(string.Format("{0}", e.Message));

            }
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        [ActionName("DeleteEmployee")]
        public IHttpActionResult DeleteEmployee(int id)
        {
            try
            {
                Trace.WriteLine(String.Format("EmployeeController - DeleteEmployee"));
                Employee result = empBL.DeleteEmployee(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                Trace.TraceError(String.Format("EmployeeController - DeleteEmployee - Error: %s", e.Message));
                return BadRequest(string.Format("{0}", e.Message));

            }

        }

        [HttpGet]
        [ActionName("SearchEmployee")]
        public IHttpActionResult SearchEmployee([FromUri] string input)
        {
            try
            {
                Trace.WriteLine(String.Format("EmployeeController - SearchEmployee"));
                return Ok(empBL.Search(input));

            }
            catch (Exception e)
            {
                Trace.TraceError(String.Format("LoginController - SearchEmployee - Error: %s", e.Message));
                return BadRequest(e.Message);
            }
        }
    }
}