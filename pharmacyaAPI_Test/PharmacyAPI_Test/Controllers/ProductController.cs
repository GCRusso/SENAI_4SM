using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyAPI_Test.Context;
using PharmacyAPI_Test.Domains;
using PharmacyAPI_Test.Interfaces;
using PharmacyAPI_Test.Repositories;

namespace PharmacyAPI_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class ProductController : ControllerBase
    {

        private IProductsRepository _productRepository;

        public ProductController()
        {
            _productRepository = new ProductsRepository();
        }

        //**************************** LISTAR TODOS **************************
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<ProductsDomain> lista = new List<ProductsDomain>();
                lista = _productRepository.Listar();
                return Ok(lista);
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
                _productRepository.Cadastrar(products);

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
                return Ok(_productRepository.BuscarPorId(id));
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
                _productRepository.Deletar(id);

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
                _productRepository.Atualizar(id, products);
                return StatusCode(200);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
