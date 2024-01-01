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
    public class PerReviewController : ApiController
    {
        [HttpGet]
        [Route("api/employee/{id}/perReview")]
        public HttpResponseMessage PerReviews(int id)
        {
            try
            {
                var data = PerReviewService.GetAll(id);
                if (data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { message = "Not found" });
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

        [HttpPost]
        [Route("api/manager/PerReview/create")]
        public HttpResponseMessage CreatePerReview(PerformanceReviewDTO pr)
        {
            try
            {
                var data = PerReviewService.Create(pr);
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Created Successfully" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("api/manager/perReview/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = PerReviewService.delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Deleted Successfully" });

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
