using BusinessLogicLayer.Services;
using BusinessLogicLayer.Services.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApplicationLayer.Controllers.Admin
{
    public class AdminController : ApiController
    {
        [HttpGet]
        [Route("api/admin/all-employees")]
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
    }
}
