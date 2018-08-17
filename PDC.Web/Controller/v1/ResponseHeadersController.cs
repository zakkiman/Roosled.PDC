using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PDC.Web.Controller.v1
{
    [AllowAnonymous]
    [Produces("application/json")]
    [Route("api/v1/ResponseHeaders")]
    public class ResponseHeadersController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            string clientID = HttpContext.Request.Headers["clientID"];
            HttpContext.Response.Headers["x-my-header"] = "header value";

            return clientID;
        }

        [HttpPost]
        public string Post([FromBody]string data)
        {
            var re = Request;
            var kepala = re.Headers;
            //if (kepala.Contains("clientID"))
            //{
            //    string token = kepala.TryGetValue("clientID");
            //}
            return kepala["clientID"];
        }
    }
}