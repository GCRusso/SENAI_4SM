using Microsoft.AspNetCore.Http.HttpResults;
using PharmacyAPI_Test.Context;
using PharmacyAPI_Test.Domains;
using PharmacyAPI_Test.Interfaces;
using System.Linq.Expressions;

namespace PharmacyAPI_Test.Repositories
{
    public class ProductsRepository : IProductsRepository
    {

        private readonly ProductContext _productContext;

        public ProductsRepository()
        {
            _productContext = new ProductContext();
        }

        //*************************** ATUALIZAR ***************************
        public void Atualizar(Guid id, ProductsDomain products)
        {
            ProductsDomain productFind = _productContext.ProductsDomain.Find(id)!;
            if (productFind != null) 
            {
                productFind.Name = products.Name;
                productFind.Price = products.Price;
            }
            else 
            {
                throw new Exception("Item não encontrado!");
            }
            _productContext.Update(productFind);
            _productContext.SaveChanges();
        }

        //*************************** BUSCAR POR ID ***************************
        public ProductsDomain BuscarPorId(Guid id)
        {
            try
            {
                ProductsDomain productFind = _productContext.ProductsDomain
                    .Select( u => new ProductsDomain
                    {
                        IdProduct = u.IdProduct,
                        Name = u.Name,
                        Price = u.Price,
                    }).FirstOrDefault(u => u.IdProduct == id)!;

                if(productFind != null)
                {
                    return productFind;
                }
                return null!;
            }
            catch (Exception)
            {
                throw new Exception ("Item não encontrado!");
            }
        }

        //*************************** CADASTRAR ***************************
        public void Cadastrar(ProductsDomain products)
        {
            _productContext.ProductsDomain.Add(products);

            _productContext.SaveChanges();
        }

        //*************************** DELETAR POR ID ***************************
        public void Deletar(Guid id)
        {
            ProductsDomain products = _productContext.ProductsDomain.Find(id);
            if (products != null) 
            {
                _productContext.ProductsDomain.Remove(products);
            }
            else
            {
                throw new Exception("Item não encontrado!");
            }
            
            _productContext.SaveChanges();
        }

        //*************************** LISTAR TODOS ***************************
        public List<ProductsDomain> Listar()
        {
           return _productContext.ProductsDomain.ToList();
        }
    }
}
