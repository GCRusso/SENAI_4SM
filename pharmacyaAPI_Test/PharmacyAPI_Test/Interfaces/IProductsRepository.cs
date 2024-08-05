using PharmacyAPI_Test.Domains;

namespace PharmacyAPI_Test.Interfaces
{
    public interface IProductsRepository
    {
        //POST
        void Cadastrar(ProductsDomain products);

        //DELETE
        void Deletar(Guid id);

        //GETBYID
        ProductsDomain BuscarPorId(Guid id);

        //GET
        List<ProductsDomain> Listar();

        //PUT
        void Atualizar(Guid id, ProductsDomain products);
    }
}
