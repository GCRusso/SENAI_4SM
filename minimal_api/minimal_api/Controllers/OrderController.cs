using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using minimal_api.Domains;
using minimal_api.Services;
using MongoDB.Driver;

namespace minimal_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMongoCollection<Order> _order;

        /// <summary>
        /// Construtor que recebe como dependencia o objeto da classe MongoDbService
        /// </summary>
        /// <param name="mongoDbService"></param>
        public OrderController(MongoDbService mongoDbService)
        {
            _order = mongoDbService.GetDatabase.GetCollection<Order>("order");
        }

        //*************************** POST (CADASTRAR) ****************************
        [HttpPost]
        public async Task<IActionResult> Post(Order order)
        {
            try
            {
                await _order.InsertOneAsync(order);

                return StatusCode(201, order);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //************************** GET (LISTAR) *****************************
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var orders = await _order.Find(x => true).ToListAsync();
                return Ok(orders);
            }
            catch (Exception e)
            {
            return BadRequest(e.Message);}
        }

        //************************* DELETE **************************
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete (string id)
        {
            try
            {
                var order = await _order.FindAsync(z => z.Id == id);

                if(order == null)
                {
                    return BadRequest("Objeto nao encontrado");
                }

                await _order.DeleteOneAsync(x => x.Id == id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //*************************** PUT (ATUALIZAR) ***********************
        [HttpPut]
        public async Task<ActionResult> Update(Order order)
        {
            try
            {
                var filter = Builders<Order>.Filter.Eq(z => z.Id, order.Id);
                await _order.ReplaceOneAsync(filter, order);

                return Ok();
            }
            catch (Exception e) 
            {
              return BadRequest(e.Message);
            }
        }

        //************************* BUSCAR POR ID **************************
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var order = await _order.Find(x => x.Id == id).FirstOrDefaultAsync();
                return order is not null ? Ok(order) : NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
