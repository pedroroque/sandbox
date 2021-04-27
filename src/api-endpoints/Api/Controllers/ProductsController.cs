namespace Api.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Api.Entities;
    using Api.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;
    using Ardalis.ApiEndpoints;
    using System.Threading;

    [ApiController]
    [Route("products")]
    public class ProductsCrudController : ControllerBase
    {
        private readonly IProductsCrudServices _crudService;
        public ProductsCrudController(IProductsCrudServices crudService) => _crudService = crudService;

        [HttpGet]
        [SwaggerOperation(Tags = new[] { "products" })]
        public async Task<IActionResult> ListAll() { return Ok(); }

        [HttpPost]
        [SwaggerOperation(Tags = new[] { "products" })]
        public async Task<IActionResult> Post(Product product) { return Ok(); }
    }

    public class SalesReportResponse { }
    public class TopSalesReportEndpoint : BaseAsyncEndpoint.WithoutRequest.WithResponse<SalesReportResponse>
    {
        private readonly IProductsSalesReporting _service;
        public TopSalesReportEndpoint(IProductsSalesReporting service) => _service = service;

        [HttpGet("products/reports/topsales")]
        [SwaggerOperation(Tags = new[] { "products" })]
        public override Task<ActionResult<SalesReportResponse>> HandleAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }


    [ApiController]
    [Route("products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsCrudServices _crudService;
        private readonly IProductsSalesReporting _salesReporting;
        private readonly IProductsInventoryReports _inventoryReports;

        public ProductsController(IProductsCrudServices crudService, IProductsSalesReporting salesReporting, IProductsInventoryReports inventoryReports)
        {
            _crudService = crudService;
            _salesReporting = salesReporting;
            _inventoryReports = inventoryReports;
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var product = await _crudService.GetByIdAsync(id);
            return product != null ? NotFound() : Ok(product);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Replace([FromRoute] Guid id, [FromBody] Product product)
        {
            await _crudService.ReplaceAsync(id, product);
            return Ok();
        }

        [HttpDelete("{id:Guid}")]
        public IActionResult Delete(Guid id)
        {
            return Ok();
        }

        // [HttpGet("reports/topsales")]
        // public IActionResult TopSales() => Ok(new { });

        [HttpGet("reports/inventory")]
        public IActionResult InventoryReports() => Ok(new { });
    }
}