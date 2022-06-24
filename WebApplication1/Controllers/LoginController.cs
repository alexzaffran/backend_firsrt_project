using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class LoginController : ApiController
    {
        static LoginBL logBL = new LoginBL();

        // GET: api/Login
        public List<User> Get()
        {
            try
            {
                Trace.WriteLine(String.Format("LoginController - Get"));
                return logBL.Getallusers();

            }
            catch (Exception e)
            {
                Trace.TraceError(String.Format("LoginController - Get - Error: %s", e.Message));
                throw new Exception(e.Message);
            }
        }

        //// GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/Login
        public IHttpActionResult AddUser(User u)
        {
            try
            {
                Trace.WriteLine(String.Format("LoginController - AddUser"));
                User result = logBL.AddUser(u);
                return Ok(result);
            }
            catch (Exception e)
            {
                Trace.TraceError(String.Format("LoginController - AddUser - Error: %s", e.Message));
                return BadRequest(String.Format("%s", e.Message));

            }
        }
   


//        // PUT api/<controller>/5
//        public void Put(int id, [FromBody] string value)
//        {
//        }

        // DELETE api/Login/5
        public string DeleteUser(int id)
        {
            logBL.DeleteUser(id);
            return "Deleted";

        }


    }
        }