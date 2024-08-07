using Moq;
using PharmacyAPI_Test.Domains;
using PharmacyAPI_Test.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PharmacyTest_Xunit
{
    public class Pharmacy_Test_Unit
    {
        //*********************** TESTE LISTAR *********************
        [Fact]
        public void Listar() 
        {
            //Arrange: Cenário
            //Lista de produtos mockados para realizar o teste
            var products = new List<ProductsDomain>
            {
                new ProductsDomain{IdProduct = Guid.NewGuid(), Name="Produto1", Price=10},
                new ProductsDomain{IdProduct = Guid.NewGuid(), Name="Produto2", Price=20},
                new ProductsDomain{IdProduct = Guid.NewGuid(), Name="Produto3", Price=30},
            };

            //Cria um Mock de simulacao do tipo IProductsRepository
            var mockRepository = new Mock <IProductsRepository>();

            //Configura o metodo Listar para retornar a lista de produtos Mock
            mockRepository.Setup(x => x.Listar()).Returns(products);

            //Act: Agir
            //Chama o metodo Listar e armazena o resultado em result 
            var result = mockRepository.Object.Listar();

            //Assert: Provar
            //Prova se o resultado esperado é igual o resultado obtido atráves da busca
            Assert.Equal(3, result.Count);
        }

        // *************************** LISTAR POR ID GETBYID*************************
        [Fact]
        public void BuscarPorId() 
        {

            //Arrange:Cenario
            //Lista de produtos
            var products = new List<ProductsDomain>
            {
                new ProductsDomain{IdProduct = Guid.NewGuid(), Name="Produto1", Price=10},
                new ProductsDomain{IdProduct = Guid.NewGuid(), Name="Produto2", Price=20},
                new ProductsDomain{IdProduct = Guid.NewGuid(), Name="Produto3", Price=30},
            };

            //Cria um Mock de simulacao do tipo IProductsRepository
            var mockRepository = new Mock<IProductsRepository>();

            //Configura o metodo BuscarPorId para retornar o produto Mock
            mockRepository.Setup(x => x.BuscarPorId(products[0].IdProduct)).Returns(products[0]);

            //Act: agir
            //Chama o metodo BuscarPorId e armazena o resultado em result
            var result = mockRepository.Object.BuscarPorId(products[0].IdProduct);

            //Assert: provar
            //Prova se o resultado esperado e igual ao resultado obtido atraves da busca
            Assert.Equal(products[0], result);
        }

        //*********************************** DELETE ******************************
        [Fact]
        public void Delete()
        {
            //Arrange: Cenario
            //Lista de produtos
            var products = new List<ProductsDomain>
            {
                new ProductsDomain{IdProduct = Guid.NewGuid(), Name="Produto1", Price=10},
                new ProductsDomain{IdProduct = Guid.NewGuid(), Name="Produto2", Price=20},
                new ProductsDomain{IdProduct = Guid.NewGuid(), Name="Produto3", Price=30},
            };

            //Cria um Mock de simulacao do tipo IProductsRepository
            var mockRepository = new Mock<IProductsRepository>();

            //Configura o metodo BuscarPorId para retornar o produto Mock
            mockRepository.Setup(x => x.Listar()).Returns(products);

            //Act: agir
            mockRepository.Object.Deletar(products[2].IdProduct);
            products.RemoveAt(2);

            mockRepository.Setup(x => x.Listar()).Returns(products);

            //Chama o metodo Listar e armazena o resultado em result
            var result = mockRepository.Object.Listar();

            //Assert: Provar
            //Prova se o resultado esperado é igual ao resultado obtido atraves da busca
            Assert.Equal(2, result.Count);
        }
        //***************************************** Cadastrar Post *********************************
        [Fact]
        public void Cadastrar() 
        {

            ProductsDomain product = new ProductsDomain { IdProduct = Guid.NewGuid(), Price = 10, Name = "Colgate" };
            var productList = new List<ProductsDomain>();

            var mockRepository = new Mock<IProductsRepository>();

            mockRepository.Setup(x => x.Cadastrar(product)).Callback<ProductsDomain>(x => productList.Add(product));

            mockRepository.Object.Cadastrar(product);

            Assert.Contains(product, productList);


        }
    }
}
