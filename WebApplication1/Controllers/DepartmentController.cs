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
    public class DepartmentController : ApiController
    {
        static DepartmentBL depBL = new DepartmentBL();

        // GET api/<controller>

        public List<Department1> Get()
        {
            try
            {
                Trace.WriteLine(String.Format("DepartmentController - Get"));
                return depBL.GetAll();

            }
            catch (Exception e)
            {
                Trace.TraceError(String.Format("LoginController - Get - Error: %s", e.Message));
                throw new Exception(e.Message);
            }
        }
    }
}

//        // GET api/<controller>/5
//        public string Get(int id)
//        {
//            return "value";
//        }

//        // POST api/<controller>
//        public void Post([FromBody] string value)
//        {
//            depBL.AddDepartment(emp);
//            return "Created!";

//        }

//        // PUT api/<controller>/5
//        public void Put(int id, [FromBody] string value)
//        {
//        }

//        // DELETE api/<controller>/5
//        public void Delete(int id)
//        {
//        }
//    }
//}