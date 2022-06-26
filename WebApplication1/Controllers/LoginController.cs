using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web;
using System.Web.Http;
using System.Web.SessionState;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class LoginController : ApiController, IRequiresSessionState
    {
        static LoginBL logBL = new LoginBL();

        // GET: api/Login
        [HttpPost]
        [ActionName("Login")]
        public IHttpActionResult Login([FromBody] UserLoginRequest body)
        {
            try
            {
                var rightUser = logBL.IsAuthenticated(body);
                Trace.WriteLine(String.Format("LoginController - Login"));
                if (rightUser != null)
                {
                    HttpContext.Current.Session["IsIsAuthenticated"] = true;
                    HttpContext.Current.Session["UserId"] = rightUser.ID;
                }
                return Ok(rightUser);

            }
            catch (Exception e)
            {
                Trace.TraceError(String.Format("LoginController - Get - Error: %s", e.Message));
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [ActionName("Logout")]
        public IHttpActionResult Logout()
        {
            try
            {
                Trace.WriteLine(String.Format("LoginController - Logout"));
                HttpContext.Current.Session.Clear();
                return Ok(true);
            }
            catch (Exception e)
            {
                Trace.TraceError(String.Format("LoginController - Logout - Error: %s", e.Message));
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [ActionName("GetAllUser")]
        public IHttpActionResult GetAllUser()
        {
            try
            {
                Trace.WriteLine(String.Format("LoginController - Get"));
                return Ok(logBL.Getallusers());

            }
            catch (Exception e)
            {
                Trace.TraceError(String.Format("LoginController - Get - Error: %s", e.Message));
                return BadRequest(e.Message);
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
        