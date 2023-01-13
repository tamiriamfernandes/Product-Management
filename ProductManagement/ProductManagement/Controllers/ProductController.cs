using Microsoft.AspNetCore.Mvc;
using ProductManagement.Domain.Contracts;
using ProductManagement.Domain.Models;
using ProductManagement.Domain.Models.Product;
using ProductManagement.Domain.Services;
using System.Net;

namespace ProductManagement.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _produtcService;
        public ProductController(IProductService productService)
        {
            _produtcService = productService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _produtcService.GetById(id);
            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("paginated")]
        public async Task<IActionResult> GetPaginated([FromQuery] PaginationParameterModel paginationParameterModel, [FromQuery] string description)
        {
            var result = await _produtcService.GetPaginated(paginationParameterModel, description);
            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CreateProductDto createProductDto)
        {
            var result = await _produtcService.Insert(createProductDto);
            
            return Created(nameof(Insert), new { Id = result } );
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductDto updateProductDto)
        {
            await _produtcService.Update(updateProductDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _produtcService.Delete(id);

            return NoContent();
        }
    }
}
