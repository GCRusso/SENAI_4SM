using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyAPI_Test.Context;
using PharmacyAPI_Test.Domains;

namespace PharmacyAPI_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductController : ControllerBase
    {
        //**************************** LISTAR TODOS **************************
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_productContext.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        //**************************** CADASTRAR **************************
        [HttpPost]

        public IActionResult Post(ProductsDomain products)
        {
            try
            {
                _productContext.Cadastrar(products);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        //**************************** BUSCAR POR ID **************************
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_productContext.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
        //**************************** DELETAR POR ID **************************

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _productContext.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        //**************************** ATUALIZAR **************************

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, ProductsDomain products)
        {
            try
            {
                _productContext.Atualizar(id, products);
                return StatusCode(200);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
