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
        private readonly IMongoCollection<Order>? _order;
        private readonly IMongoCollection<Product>? _product;
        private readonly IMongoCollection<Client>? _client;

        /// <summary>
        /// Construtor que recebe como dependencia o objeto da classe MongoDbService
        /// </summary>
        /// <param name="mongoDbService"></param>
        public OrderController(MongoDbService mongoDbService)
        {
            _client = mongoDbService.GetDatabase?.GetCollection<Client>("client");
            _product = mongoDbService.GetDatabase?.GetCollection<Product>("product");
            _order = mongoDbService.GetDatabase?.GetCollection<Order>("order");
        }

        //*************************** POST (CADASTRAR) ****************************
        [HttpPost]
        public async Task<ActionResult<Order>> Create(OrderViewModel orderViewModel)
        {
            try
            {
                Order order = new Order();

                order.Id = orderViewModel.Id;
                order.Date = orderViewModel.Date;
                order.Status = orderViewModel.Status;
                order.ProductId = orderViewModel.ProductId;
                order.ClientId = orderViewModel.ClientId;

                //ira buscar na collection _client e verificar se o Id que foi passado existe, se existir guarde na variavel client'
                var client = await _client.Find(x => x.Id == order.ClientId).FirstOrDefaultAsync();

                if (client == null)
                {
                    return NotFound();
                }

                //Pega todos os dados que inserimos no client e adicionamos no Client
                order.Client = client;

                //Insere na ordem
                await _order!.InsertOneAsync(order);

                //Retorna um statuscode 
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
                //Filtro de pesquisa
                var orders = await _order.Find(x => true).ToListAsync();
                var client = await _client.Find(x => true).ToListAsync();

                // Incluir produtos em cada pedido
                foreach (var order in orders)
                {
                    order.Products = await _product.Find(x => order.ProductId!.Contains(x.Id!)).ToListAsync();
                }

                return Ok(orders);
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
                var order = await _order.FindAsync(z => z.Id == id);

                if (order == null)
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
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, OrderViewModel orderViewModel)
        {
            try
            {
                var order = await _order.Find(x => x.Id == id).FirstOrDefaultAsync();

                if (order == null)
                {
                    return NotFound("Não foi possível localizar a ordem");
                }

                order.Date = orderViewModel.Date;
                order.Status = orderViewModel.Status;
                order.ProductId = orderViewModel.ProductId;
                order.ClientId = orderViewModel.ClientId;

                var client = await _client.Find(x => x.Id == order.ClientId).FirstOrDefaultAsync();


                order.Client = client;
                order.Products = await _product.Find(x => order.ProductId!.Contains(x.Id!)).ToListAsync();

                var filter = Builders<Order>.Filter.Eq(z => z.Id, id);
                await _order!.ReplaceOneAsync(filter, order);

                return Ok(order);
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
                var orderFind = await _order.Find(x => x.Id == id).FirstOrDefaultAsync();

                if (orderFind == null)
                {
                    return NotFound("Não foi possível localizar a ordem");
                }


                var client = await _client.Find(x => x.Id == orderFind.ClientId).FirstOrDefaultAsync();
                var products = await _product.Find(x => orderFind.ProductId!.Contains(x.Id!)).ToListAsync();

                orderFind.Client = client;
                orderFind.Products = products;

                return orderFind is not null ? Ok(orderFind) : NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /*
        //**************************** EXEMPLO DO PROFESSOR GET **************************
        public async Task<ActionResult<List<Order>>> Get()
        {
            try
            {
                //lista todos os pedidos da collection "Order"
                var orders = await _order.Find(FilterDefinition<Order>.Empty).ToListAsync();

                //percorre todos os itens da lista
                foreach (var order in orders)
                {
                    if(order.ProductId != null)
                    {
                        //dentro da collection "Product" faz um filtro ("separa" os produtos que estao dentro do pedido)
                        //olha, selecione os ids dos produtos dentro da collection cujo id esta presente na lista "order.ProductId"
                        var filter = Builders<Product>.Filter.In(p => p.Id, order.ProductId);

                        //busca os produtos correspondentes ao pedido e adiciona em "order.Products"
                        //traz as informacoes dos produtos
                        order.Products = await _product.Find(filter).ToListAsync();
                    }

                    //Busca e associa o cliente correspondente ao pedido
                    if(order.ClientId != null)
                    {
                        order.Client = await _client.Find(x => x.Id == order.ClientId).FirstOrDefaultAsync();
                    }
                }
                return Ok(order);
            }
            catch(Exception e) 
            {
                return BadRequest(e.Message);
            }
        }
        */
    }
}
