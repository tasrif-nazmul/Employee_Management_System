using BusinessLogicLayer.DTOs.AdminDTOs;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.Services.Admin;
using BusinessLogicLayer.Services.EmployeeServices;
using BusinessLogicLayer.Services.ManegerServices;
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

        [HttpPost]
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

        [HttpPost]
        [Route("api/admin/create-employee")]

        public HttpResponseMessage Create(AdminDTO obj) {
            try
            {
                AdminService.Add(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Created Successfully" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/admin/update-employee")]

        public HttpResponseMessage Update(AdminDTO obj)
        {
            try
            {
                AdminService.Update(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Updated Successfully" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/admin/add-payroll")]
        public HttpResponseMessage Create(PayrollDTO obj)
        {
            try
            {
                BusinessLogicLayer.Services.Admin.PayrollService.Add(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Payroll Created Successfully" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }
    }
}
