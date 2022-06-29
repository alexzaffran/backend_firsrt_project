using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webapplication1.models;
using WebApplication1.Models;
using System.Web;
using System.Web.Http.Cors;

namespace WebApplication1.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ShiftController : ApiController
    {
        static ShiftBl shiftBL = new ShiftBl();

        [HttpPost]
        [ActionName("addShift")]
        public IHttpActionResult addShift([FromBody] Shift body, [FromUri] int employeeId)
        {
            try
            {

                Trace.WriteLine(String.Format("ShiftController - addShift"));
                return Ok(shiftBL.addshift(body, employeeId));

            }
            catch (Exception e)
            {
                Trace.TraceError(String.Format("ShiftController - addShift - Error: %s", e.Message));
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [ActionName("getAllShift")]
        public IHttpActionResult getAllShift()
        {
            try
            {
                Trace.WriteLine(String.Format("ShiftController - getAllShift"));
                return Ok(shiftBL.getAllShiftWithEmlpoyeeData());

            }
            catch (Exception e)
            {
                Trace.TraceError(String.Format("ShiftController - getAllShift - Error: %s", e.Message));
                return BadRequest(e.Message);
            }
        }
    }
}
