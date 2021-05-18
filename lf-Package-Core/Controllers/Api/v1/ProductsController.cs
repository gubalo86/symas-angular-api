using Microsoft.AspNetCore.Mvc;
using Symas.SymasSalud.Interfaces;
using Symas.SymasSalud.Models;
using System.Threading.Tasks;

namespace lf_Package_Core.Controllers.Api.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(
            IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productService.GetAllAsync();

            if (!result.IsSuccessful) result.Throw();

            return Ok(result.Data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _productService.FindByIdAsync(id);

            if (!result.IsSuccessful) result.Throw();

            return Ok(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductModel model) {
            var result = await _productService.CreateAsync(model);

            if (!result.IsSuccessful) result.Throw();

            return Ok(result.Data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id,ProductModel model)
        {
            model.Id = id;
            var result = await _productService.UpdateAsync(model);

            if (!result.IsSuccessful) result.Throw();

            return Ok(result.Data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id) {
            var result = await _productService.DeleteAsync(id);

            if (!result.IsSuccessful) result.Throw();

            return Ok(result.Data);
        }
    }
}