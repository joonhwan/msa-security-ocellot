using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MireroTicket.ServiceBus.TestMessages;

namespace MireroTicket.ServiceBus.TestClient.Controllers
{
    [ApiController]
    // [Route("/api/publish")]
    public class ServiceBusController : ControllerBase
    {
        private readonly IMessageProducer<TestProduceMessage> _producer;
        private readonly IMessagePublisher<TestPublishMessage> _publisher;
        private readonly ILogger<ServiceBusController> _logger;

        public ServiceBusController(
            IMessageProducer<TestProduceMessage> producer,
            IMessagePublisher<TestPublishMessage> publisher,
            ILogger<ServiceBusController> logger
            )
        {
            _producer = producer;
            _publisher = publisher;
            _logger = logger;
        }

        [HttpPost("/api/publish")]
        public async Task<IActionResult> Publish([FromBody]string message)
        {
            await _publisher.Publish(new TestPublishMessage
            {
                CreatedAt = DateTime.Now,
                Body = message,
            });
            return Ok();
        }
        
        [HttpPost("/api/produce")]
        public async Task<IActionResult> Produce([FromBody]string message)
        {
            await _producer.Produce(new TestProduceMessage
            {
                CreatedAt = DateTime.Now,
                Body = message
            });
            return Ok();
        }
    }
}