using Microsoft.AspNetCore.Mvc;
using WebApplicationDemo.Services.Interfaces;

namespace WebApplicationDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CounterController : ControllerBase
    {
        private ICounterService _counterService;

        public CounterController(ICounterService counterService)
        {
            _counterService = counterService;
        }

        [HttpGet(nameof(GetCurrentCounter))]
        public IActionResult GetCurrentCounter()
        {
            return new OkObjectResult(_counterService.GetCounter());
        }

        [HttpGet(nameof(IncrementCounter))]
        public IActionResult IncrementCounter()
        {
            _counterService.Increment();
            return new OkObjectResult("SUCCESS!");
        }
    }
}
