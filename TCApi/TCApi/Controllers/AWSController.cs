using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.S3;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TCApi.AWS;
using TCApi.Models;

namespace TCApi.Controllers
{
    [Route("api/aws")]
    [ApiController]
    public class AwsController : ControllerBase
    {
        private readonly IAwsMethods _awsMethods;
        private readonly ILogger _logger;


        public AwsController(IAwsMethods awsMethods,
            ILogger<IAmazonS3> logger)
        {
            _awsMethods = awsMethods;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<string>> GetAll()
        {
            _logger.Log(LogLevel.Information, "AwsController.GetAll");
            var response = _awsMethods.GetAllRecordsNameAsync();
            return response.Result;
        }

        [HttpGet("{key}", Name = "GetRecord")]
        public ActionResult<string> GetRecord(string key)
        {
            _logger.Log(LogLevel.Information, $"AwsController.GetRecord {key}");
            var response =  _awsMethods.GetDataByKeyAsync(key);
            return response.Result;
        }
    }
}
