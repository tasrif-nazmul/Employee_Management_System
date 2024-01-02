using ApplicationLayer.Auth;
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
    public class AssignedTaskController : ApiController
    {
        [ELogged]
        [HttpGet]
        [Route("api/employee/task")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var data = AssignedTaskService.GetAll();
                if(data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new {message="No task assigned yet"});
                }
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new {message= ex.Message});
            }
        }

        [HttpGet]
        [Route("api/employee/task/{id}")]
        public HttpResponseMessage GetTask(int id)
        {
            try
            {
                var data = AssignedTaskService.Get(id);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Data not found" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new {message= ex.Message});
            }
        }

        [HttpPost]
        [Route("api/employee/task/accept/{id}")]
        public HttpResponseMessage ReceiveTask(int id, AssignedTaskDTO obj)
        {
            try
            {
                AssignedTaskService.Received(id, obj);
                return Request.CreateResponse(HttpStatusCode.OK, new {message="Task Accepted"} );
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new {message=ex.Message});
            }
        }
        
        [HttpPost]
        [Route("api/employee/task/submit/{id}")]
        public HttpResponseMessage CompletedTask(int id, AssignedTaskDTO obj)
        {
            try
            {
                AssignedTaskService.Submit(id, obj);
                return Request.CreateResponse(HttpStatusCode.OK, new {message="Task Submitted Successfully"} );
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new {message=ex.Message});
            }
        }

        //EmployeeTask
        [HttpGet]
        [Route("api/employee/{id}/task")]
        public HttpResponseMessage EmployeeTask(int id)
        {
            try
            {
                var data = AssignedTaskService.GetEmployeeWithTasks(id);
                if(data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new {message="Data not found"});
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

    }
}
