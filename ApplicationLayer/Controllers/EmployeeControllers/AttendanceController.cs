using BusinessLogicLayer.DTOs.EmployeeDTOs;
using BusinessLogicLayer.Services.EmployeeServices;
using DataAccessLayer.EF;
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
        [Route("api/employee/{id}/entry")]
        public HttpResponseMessage CreateEntryAttendance(int id)
        {
            try
            {
                var data = AttendanceService.CreateEntry(id);
                if(data)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { message = "Entry Successfully" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { message = "Invalid Employee ID" });
                }   
                
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new {message=ex.Message});
            }
        }
        
        [HttpPost]
        [Route("api/employee/{id}/exit")]
        public HttpResponseMessage CreateExitAttendance(int id)
        {
            try
            {
                var data = AttendanceService.CreateExit(id);
                if(data)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { message = "Exit Successfully" });
                }
                else
                {
                    var db = new EmployeeManagementEntities1();
                    bool employeeExists = db.Employees.Any(e => e.EmployeeID == id);

                    if (!employeeExists)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { message = "Invalid Employee ID" });
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = "No entry found for exit" });
                    }
                }   
                
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = ex.Message });
            }
        }
    }
}
