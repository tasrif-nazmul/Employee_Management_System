using BusinessLogicLayer.Services;
using BusinessLogicLayer.Services.Admin;
using BusinessLogicLayer.Services.EmployeeServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Services.Description;

namespace ApplicationLayer.Controllers.Admin
{
    public class AdminController : ApiController
    {
        [HttpGet]
        [Route("api/admin/get-all")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var data = AdminService.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }

        [HttpGet]
        [Route("api/admin/get/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = AdminService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }

        [HttpDelete]
        [Route("api/admin/delete-employee/{id}")]

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = AdminService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Deleted Successfully" });

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
