using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PA.Api.Models;
using PA.Log.Manager;

namespace PA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ILog log;

        public LogController(ILog log)
        {
            this.log = log;
        }

        [HttpGet]
        public IActionResult LogSummary()
        {
            var logItems = log.GetLogs();
            var res = (logItems.Where(x => x.INFORMATION_TYPE.Equals("REQUEST"))
                       .GroupBy(g => g.RawRequest.ApiId)
                       .Select(s => new LogReport
                       {
                           ApiId = s.Key,
                           Count = s.Count()
                       })).ToList();

            return new OkObjectResult(res);
        }

        [HttpGet("{id}")]
        public IActionResult LogById(string id)
        {
            var logItems = log.GetLogs(id);
            var request = logItems.Where(x => x.INFORMATION_TYPE.Equals("REQUEST")).FirstOrDefault();
            var response = logItems.Where(x => x.INFORMATION_TYPE.Equals("RESPONSE")).FirstOrDefault();
            var res = new LogDetail()
            {
                ID = id,
                RequestTime = request?.Time,
                Request = request == null ? "" : JsonConvert.SerializeObject(request.RawRequest),
                ResponseTime = response?.Time,
                Response = response?.Response,
                Duration = response?.Duration,
            };

            return new OkObjectResult(res);
        }
    }
}
