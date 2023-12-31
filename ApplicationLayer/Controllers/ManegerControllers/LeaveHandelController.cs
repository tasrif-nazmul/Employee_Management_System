using BusinessLogicLayer.DTOs.EmployeeDTOs;
using BusinessLogicLayer.Services.EmployeeServices;
using BusinessLogicLayer.Services.ManegerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApplicationLayer.Controllers.ManegerControllers
{
    public class LeaveHandelController : ApiController
    {
        [HttpGet]
        [Route("api/maneger/leaverequest/list")]
        public HttpResponseMessage GetLeaveReqs()
        {
            try
            {
                var data = LeaveRequestService.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/maneger/leaverequest/{id}")]
        public HttpResponseMessage GetLeaveReq(int id)
        {
            try
            {
                var data = LeaveRequestService.Get(id);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Data not found" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPut]
        [Route("api/maneger/leaverequest/accept/{id}")]
        public HttpResponseMessage Accept(int id, LeaveRequestDTO obj)
        {
            try
            {

                LeaveHandelService.Accept(id, obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Accept" });


            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPut]
        [Route("api/maneger/leaverequest/reject/{id}")]
        public HttpResponseMessage Reject(int id, LeaveRequestDTO obj)
        {
            try
            {

                LeaveHandelService.Reject(id, obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Reject" });


            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
