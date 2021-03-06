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
    public class DepartmentController : ApiController
    {
        static DepartmentBL depBL = new DepartmentBL();

        // GET api/<controller>
        [HttpGet]
        [ActionName("GetAllDepartments")]
        public IHttpActionResult GetAllDepartmentsData()
        {
            try
            {
                Trace.WriteLine(String.Format("DepartmentController - Get"));
                return Ok(depBL.GetAllDepartmentsData());

            }
            catch (Exception e)
            {
                Trace.TraceError(String.Format("LoginController - Get - Error: %s", e.Message));
               return BadRequest(e.Message);
            }
        }



        // GET api/<controller>/5


        [HttpGet]
        [ActionName("GetDep")]

        public IHttpActionResult GetDepById(int id)
        {
            try
            {
                Trace.WriteLine(String.Format("DepartmentController - GetDepById"));
                DepartmentData result = depBL.GetDepById(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                Trace.TraceError(String.Format("LoginController - AddUser - Error: %s", e.Message));
                return BadRequest(String.Format("{0}", e.Message));

            }
        }





        //POST api/<controller>
        [HttpPost]
        [ActionName("AddDep")]

        public IHttpActionResult AddDep(Department1 dep)
        {
            try
            {
                Trace.WriteLine(String.Format("DepartmentController - GetDepById"));
                Department1 result = depBL.AddDep(dep);
                return Ok(result);
            }
            catch (Exception e)
            {
                Trace.TraceError(String.Format("LoginController - AddUser - Error: %s", e.Message));
                return BadRequest(String.Format("{0}", e.Message));

            }
        }

        [HttpPut]
        [ActionName("editDep")]

        public IHttpActionResult editDep([FromBody] Department1 data, [FromUri] int depId)
        {
            try
            {
                Trace.WriteLine(String.Format("DepartmentController - editDep"));
                Department1 result = depBL.editOne(data, depId);
                return Ok(result);
            }
            catch (Exception e)
            {
                Trace.TraceError(String.Format("LoginController - editDep - Error: %s", e.Message));
                return BadRequest(String.Format("{0}", e.Message));

            }
        }

        [HttpDelete]
        [ActionName("deleteDep")]

        public IHttpActionResult deleteDep([FromUri] int depId)
        {
            try
            {
                Trace.WriteLine(String.Format("DepartmentController - deleteDep"));
                Department1 result = depBL.delete(depId);
                return Ok(result);
            }
            catch (Exception e)
            {
                Trace.TraceError(String.Format("LoginController - deleteDep - Error: %s", e.Message));
                return BadRequest(String.Format("{0}", e.Message));

            }
        }
    }
}
        

////        // put api/<controller>/5
//        public void Put(int id, [FromBody] string value)
//        {
//        }

//        // DELETE api/<controller>/5
//        public void Delete(int id)
//        {
//        }
//    }
//}