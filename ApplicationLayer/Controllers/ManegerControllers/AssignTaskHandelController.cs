using BusinessLogicLayer.DTOs.EmployeeDTOs;
using BusinessLogicLayer.Services.ManegerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApplicationLayer.Controllers.ManegerControllers
{
    public class AssignTaskHandelController : ApiController
    {
        [HttpPost]
        [Route("api/manager/task/create")]
        public HttpResponseMessage CreateTask(AssignedTaskDTO obj)
        {
            try
            {
                AssignTaskHandelService.CreateTask(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new {message="Created Successfully"});
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new {message= ex.Message});
            }
        }
    }
}
