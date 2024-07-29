using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using minimal_api.Domains;
using minimal_api.Services;
using MongoDB.Driver;

namespace minimal_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMongoCollection<User> _user;

        /// <summary>
        /// Construtor que recebe como dependencia o objeto da classe MongoDbService
        /// </summary>
        /// <param name="mongoDbService"></param>
        public UserController(MongoDbService mongoDbService)
        {
            _user = mongoDbService.GetDatabase.GetCollection<User>("user");
        }

        //*************************** POST (CADASTRAR) ****************************
        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            try
            {
                await _user.InsertOneAsync(user);

                return StatusCode(201, user);
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
                var users = await _user.Find(FilterDefinition<User>.Empty).ToListAsync();
                return Ok(users);
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
                var user = await _user.FindAsync(z => z.Id == id);

                if (user == null)
                {
                    return BadRequest("Objeto nao encontrado");
                }

                await _user.DeleteOneAsync(x => x.Id == id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //************************* PUT (ATUALIZAR) **************************
        [HttpPut]
        public async Task<ActionResult> Update(User user)
        {
            try
            {
                var filter = Builders<User>.Filter.Eq(z => z.Id, user.Id);
                await _user.ReplaceOneAsync(filter, user);

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
                var user = await _user.Find(x => x.Id == id).FirstOrDefaultAsync();
                return user is not null ? Ok(user) : NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
