using BusinessLogicLayer.Services.EmployeeServices;
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
    }
}
