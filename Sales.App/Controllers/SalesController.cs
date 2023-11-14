using Microsoft.AspNetCore.Mvc;
using Sales.Domain.Sales;
using Sales.Services.Sales;

namespace Sales.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISaleService _saleService;
        public SalesController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpGet("GetAllSales")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var coursesResponse = await _saleService.GetAllSales();
                return coursesResponse == null ? NotFound() : Ok(coursesResponse);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                return StatusCode(500, "Internal server error, please contact support");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] Sale request)
        {
            try
            {
                var memberResponse = _saleService.InsertSale(request);
                return memberResponse != null ? Created("Created", true) : StatusCode(503, "Internal server error, not stored correctly.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                return StatusCode(500, "Internal server error, please contact support");
            }
        }
    }
}
