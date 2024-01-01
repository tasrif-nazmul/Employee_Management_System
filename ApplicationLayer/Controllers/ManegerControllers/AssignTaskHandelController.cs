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
        [Route("api/maneger/task/create")]
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

        [HttpGet]
        [Route("api/maneger/task/list")]
        public HttpResponseMessage GetTasks()
        {
            try
            {
                var data = AssignTaskHandelService.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/maneger/task/{id}")]
        public HttpResponseMessage GetTask(int id)
        {
            try
            {
                var data = AssignTaskHandelService.Get(id);
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

        [HttpDelete]
        [Route("api/maneger/task/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = AssignTaskHandelService.delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Deleted Successfully" });

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPut]
        [Route("api/maneger/task/update/{id}")]
        public HttpResponseMessage Update(int id, AssignedTaskDTO obj)
        {
            try
            {

                if (obj == null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { message = "Please put data" });
                }
                else
                {
                    AssignTaskHandelService.update(id, obj);
                    return Request.CreateResponse(HttpStatusCode.OK, new { message = "Updated Successfully" });
                }

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = ex.Message });
            }
        }
    }
}
