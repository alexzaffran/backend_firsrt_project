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
namespace WebApplication1.Controllers
{
    public class ShiftController : ApiController
    {
        static ShiftBl shiftBL = new ShiftBl();

        [HttpPost]
        [ActionName("addShift")]

        public Shift addShift(int employeeId, [FromBody] Shift body)
        {
            try
            {

                Trace.WriteLine(String.Format("ShiftController - addShift"));
                return shiftBL.addshift(body, employeeId);

            }
            catch (Exception e)
            {
                Trace.TraceError(String.Format("ShiftController - addShift - Error: %s", e.Message));
                throw new Exception(e.Message);
            }
        }

        [HttpGet]
        [ActionName("getAllShift")]
        public List<ShiftData> getAllShift()
        {
            try
            {
                Trace.WriteLine(String.Format("ShiftController - getAllShift"));
                return shiftBL.getAllShiftWithEmlpoyeeData();

            }
            catch (Exception e)
            {
                Trace.TraceError(String.Format("ShiftController - getAllShift - Error: %s", e.Message));
                throw new Exception(e.Message);
            }
        }
    }
}
