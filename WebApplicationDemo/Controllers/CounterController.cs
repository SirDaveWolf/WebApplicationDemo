using Microsoft.AspNetCore.Mvc;
using WebApplicationDemo.Exceptions;
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
            try
            {
                return new OkObjectResult(_counterService.GetCounter());
            }
            catch(FileSystemException)
            {
                return new StatusCodeResult(500);
            }
        }

        [HttpGet(nameof(IncrementCounter))]
        public IActionResult IncrementCounter()
        {
            try
            {
                _counterService.Increment();
                return new OkObjectResult("SUCCESS!");
            }
            catch(FileSystemException)
            {
                return new StatusCodeResult(500);
            }
        }
    }
}
