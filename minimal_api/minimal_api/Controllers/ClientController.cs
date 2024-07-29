using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using minimal_api.Domains;
using minimal_api.Services;
using MongoDB.Driver;

namespace minimal_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IMongoCollection<Client> _client;

        /// <summary>
        /// Construtor que recebe como dependencia o objeto da classe MongoDbService
        /// </summary>
        /// <param name="mongoDbService"></param>
        public ClientController(MongoDbService mongoDbService)
        {
            _client = mongoDbService.GetDatabase.GetCollection<Client>("client");
        }

        //*************************** POST (CADASTRAR) ****************************
        [HttpPost]
        public async Task<IActionResult> Post(Client client)
        {
            try
            {
                await _client.InsertOneAsync(client);

                return StatusCode(201, client);
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
                var clients = await _client.Find(FilterDefinition<Client>.Empty).ToListAsync();
                return Ok(clients);
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
                var client = await _client.FindAsync(z => z.Id == id);

                if (client == null)
                {
                    return BadRequest("Objeto nao encontrado");
                }

                await _client.DeleteOneAsync(x => x.Id == id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //************************* PUT (ATUALIZAR) **************************
        [HttpPut]
        public async Task<ActionResult> Update(Client client)
        {
            try
            {
                var filter = Builders<Client>.Filter.Eq(z => z.Id, client.Id);
                await _client.ReplaceOneAsync(filter, client);

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
                var client = await _client.Find(x => x.Id == id).FirstOrDefaultAsync();
                return client is not null ? Ok(client) : NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
