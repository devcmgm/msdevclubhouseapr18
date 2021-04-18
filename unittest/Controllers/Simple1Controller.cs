using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace unittest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Simple1Controller : ControllerBase
    {
        private static readonly string[] SampleData = new[]
        {
            "{ data: \"data 1\" }", "{ data: \"data 22\" }", "{ data: \"data 333\" }"
        };

        private readonly ILogger<Simple1Controller> _logger;

        public Simple1Controller(ILogger<Simple1Controller> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Simple1> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Simple1
            {
                Date = DateTime.Now.AddDays(index),
                JsonData = SampleData[rng.Next(SampleData.Length)]
            })
            .ToArray();
        }
    }
}
