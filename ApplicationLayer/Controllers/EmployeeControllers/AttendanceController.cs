using BusinessLogicLayer.DTOs.EmployeeDTOs;
using BusinessLogicLayer.Services.EmployeeServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApplicationLayer.Controllers.EmployeeControllers
{
    public class AttendanceController : ApiController
    {
        [HttpPost]
        [Route("api/employee/attendance/entry")]
        public HttpResponseMessage CreateEntryAttendance(AttendanceRecordsDTO obj)
        {
            try
            {
                if (obj == null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { message = "Please put data" });
                }
                else
                {
                    var data = AttendanceService.CreateEntry(obj);
                    return Request.CreateResponse(HttpStatusCode.OK, new { message = "Attendance Successfully" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        
        //[HttpPost]
        //[Route("api/employee/attendance/exit")]
        //public HttpResponseMessage CreateExitAttendance(AttendanceRecordsDTO obj)
        //{
        //    try
        //    {
        //        if (obj == null)
        //        {
        //            return Request.CreateResponse(HttpStatusCode.OK, new { message = "Please put data" });
        //        }
        //        else
        //        {
        //            var data = AttendanceService.CreateEntry(obj);
        //            return Request.CreateResponse(HttpStatusCode.OK, new { message = "Attendance Successfully" });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
        //    }
        //}
    }
}
