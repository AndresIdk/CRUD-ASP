using Asp.Datos;
using Asp.Model;
using Microsoft.AspNetCore.Mvc;

namespace Asp.Controllers
{
    [ApiController]
    [Route("/api/products")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Mproduct>>> showProducts()
        {
            var Dproducts = new Dproducts();
            var products = await Dproducts.ShowProducts();
            return products;
        }

        [HttpPost]
        public async Task insertProducts([FromBody] Mproduct parameters)
        {
            var response = new Dproducts();
            await response.IntertProducts(parameters);
        }

        [HttpPut("{id}")]
        public async Task <ActionResult>updateProduct(int id, [FromBody] Mproduct parameters)
        {
            var response = new Dproducts();
            parameters.id = id;
            await response.updateProducts(parameters);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task <ActionResult> deleteProducts(int id)
        {
            var response = new Dproducts();
            await response.deleteProducts(id);
            return NoContent();
        }
    }
}
