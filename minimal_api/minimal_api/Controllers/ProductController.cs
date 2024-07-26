using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using minimal_api.Domains;
using minimal_api.Services;
using MongoDB.Driver;

namespace minimal_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMongoCollection<Product> _product;

        /// <summary>
        /// Construtor que recebe como dependencia o objeto da classe MongoDbService
        /// </summary>
        /// <param name="mongoDbService"></param>
        public ProductController(MongoDbService mongoDbService)
        {
            _product = mongoDbService.GetDatabase.GetCollection<Product>("product");
        }

        //************************** GET *****************************
        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            try 
            {
                var products = await _product.Find(FilterDefinition<Product>.Empty).ToListAsync();
                return Ok(products);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //*************************** POST ****************************
        [HttpPost]
        public async Task <IActionResult> Post(Product product)
        {
            try
            {
                await _product.InsertOneAsync(product);

                return StatusCode(201, product);
            }
            catch (Exception e) 
            {
                return BadRequest(e.Message);
            }

        }

        //************************* DELETE **************************
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var product = await _product.FindAsync(z => z.Id == id);

                if (product == null)
                {
                    return BadRequest("Objeto nao encontrado");
                }

                await _product.DeleteOneAsync(x => x.Id == id);
                return NoContent();
            }
            catch (Exception e) 
            {

                return BadRequest(e.Message);
            }
        }


    }
}
