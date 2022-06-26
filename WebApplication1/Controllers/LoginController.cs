using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class LoginController : ApiController
    {
        static LoginBL logBL = new LoginBL();

        // GET: api/Login
        [HttpPost]
        [ActionName("Login")]
        public User Login([FromBody] UserLoginRequest body)
        {
            try
            {
                var rightUser = logBL.IsAuthenticated(body);
                Trace.WriteLine(String.Format("LoginController - Login"));
                if (rightUser != null)
                {
                    HttpContext.Current.Session["isIsAuthenticated"] = true;
                    HttpContext.Current.Session["userId"] = rightUser.ID;
                }
                return rightUser;

            }
            catch (Exception e)
            {
                Trace.TraceError(String.Format("LoginController - Get - Error: %s", e.Message));
                throw new Exception(e.Message);
            }
        }

        [HttpGet]
        [ActionName("Logout")]
        public void Logout()
        {
            try
            {
                Trace.WriteLine(String.Format("LoginController - Logout"));
                HttpContext.Current.Session.Clear();
            }
            catch (Exception e)
            {
                Trace.TraceError(String.Format("LoginController - Logout - Error: %s", e.Message));
                throw new Exception(e.Message);
            }
        }

        [HttpGet]
        [ActionName("GetAllUser")]
        public List<User> GetAllUser()
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
        [HttpPost]
        [ActionName("AddUser")]
        public IHttpActionResult AddUser([FromBody] User u)
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
                return BadRequest(String.Format("{0}", e.Message));

            }
        }



        //        // PUT api/<controller>/5
        //        public void Put(int id, [FromBody] string value)
        //        {
        //        }

        // DELETE api/Login/5
        [HttpDelete]
        [ActionName("DeleteUser")]
        public IHttpActionResult DeleteUser(int id)
        {
   
            try
            {
                Trace.WriteLine(String.Format("LoginController - DeleteUser"));
                User result = logBL.DeleteUser(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                Trace.TraceError(String.Format("LoginController - DeleteUser - Error: %s", e.Message));
                return BadRequest(string.Format("{0}", e.Message));

            }
        }

    }


}
        