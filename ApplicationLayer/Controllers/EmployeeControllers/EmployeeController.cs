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
    public class EmployeeController : ApiController
    {
        [HttpGet]
        [Route("api/employee/leave-request/create")]
        public HttpResponseMessage CreateLeaveReq(LeaveRequestDTO lr)
        {
            try
            {
                var data = LeaveRequestService.Create(lr);
                return Request.CreateResponse(HttpStatusCode.OK, new {message="Created Successfully"});
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
