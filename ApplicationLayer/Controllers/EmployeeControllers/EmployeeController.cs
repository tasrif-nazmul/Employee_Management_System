﻿using BusinessLogicLayer.DTOs.EmployeeDTOs;
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
        [HttpPost]
        [Route("api/employee/leave-request/create")]
        public HttpResponseMessage CreateLeaveReq(LeaveRequestDTO lr)
        {
            try
            {
                var data = LeaveRequestService.Create(lr);
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Created Successfully" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/employee/leave-request/list")]
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
        [Route("api/employee/leave-request/{id}")]
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
        [Route("api/employee/leave-request/update/{id}")]
        public HttpResponseMessage Update(int id, LeaveRequestDTO obj)
        {
            try
            {

                if (obj == null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { message = "Please put data" });
                }
                else
                {
                    LeaveRequestService.update(id, obj);
                    return Request.CreateResponse(HttpStatusCode.OK, new { message = "Updated Successfully" });
                }

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        [Route("api/employee/leave-request/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = LeaveRequestService.delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Deleted Successfully" });

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        //Performance review
        [HttpGet]
        [Route("api/employee/{id}/performance")]
        public HttpResponseMessage EmployeeTask(int id)
        {
            try
            {
                var data = PerformanceReviewService.GetEmployeeWithPerformance(id);
                if (data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { message = "Data not found" });
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

        //Payroll

        [HttpGet]
        [Route("api/employee/payroll/search")]
        public HttpResponseMessage SearchPayrollData(PayrollDTO obj)
        {
            try
            {
                if (obj == null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { message = "Please insert data" });
                }
                else
                {
                    var payrollData = PayrollService.SearchPayrollData(obj);
                    return Request.CreateResponse(HttpStatusCode.OK, payrollData);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }

        }
        [HttpGet]
        [Route("api/employee/{id}/payslip")]
        public HttpResponseMessage PaySlip(int id)
        {
            try
            {
                var data = PayrollService.GetPaySlip(id);
                if (data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { message = "Data not found" });
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
