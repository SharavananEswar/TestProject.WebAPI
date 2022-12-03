using Microsoft.AspNetCore.Mvc;
using ZipPay.WebApi.DTOs;

namespace TestProject.WebAPI.Controllers
{
    public class StatusController : Controller
    {
        private static readonly string _version = "0.0.1";

        [HttpGet("api/v1/status")]
        public StatusResponse Get()
        {
            //TODO: check dependent service status
            return new StatusResponse { Name = "ZipPayApi", Status = "OK", Version = _version };

        }
    }
}
