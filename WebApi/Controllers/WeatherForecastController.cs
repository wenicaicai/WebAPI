using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("weatherForecast")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [Route("Run")]
        public ActionResult Run()
        {
            Socket socket = new Socket();
            return Ok(socket.run());
        }

        /// <summary>
        /// a get request
        /// 添加描述响应文档，让WebApi开发人员对预期结果有所了解。
        /// </summary>
        /// <remarks>
        /// 例如：/weatherForecast/2
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>测试结果</returns>
        /// <response code="201">返回value字符串</response>
        /// <response code="400">如果id为空</response>
        [HttpGet("{id}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult<string> Get(string id)
        {
            return $"您的请求id：{id}";
        }

        [HttpGet]
        [Route("RegionTest")]
        public ActionResult<string> RegionTest()
        {
            int[] a = { 1, 2, 3, 4 };
            var result = Region.region(a, 0, 0);
            var resut_string = result.ToString();
            return $"递归测试结果：{resut_string}";
        }
    }
}
