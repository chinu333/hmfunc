using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Hallmark.Function
{
    public class HallmarkFunc
    {
        private readonly ILogger<HallmarkFunc> _logger;

        public HallmarkFunc(ILogger<HallmarkFunc> log)
        {
            _logger = log;
        }

        [FunctionName("HallmarkFunc")]
        public void Run([ServiceBusTrigger("hallmarktopic", "hallmarksubs", Connection = "hallmarkpoc_SERVICEBUS")]string mySbMsg)
        {
            _logger.LogInformation($"C# ServiceBus topic trigger function processed message: {mySbMsg}");
        }
    }
}
