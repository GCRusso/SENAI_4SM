using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace minimal_api.Domains
{
    public class Order
    {
        [BsonId]//define que esta prop é Id do objeto
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)] // Define o nome do campo no MongoDb como "_id" e o tipo como "ObjectedId"
        public string? Id { get; set; }

        [BsonElement("date")]
        public DateTime? Date { get; set; }

        [BsonElement("status")]
        public string? Status { get; set; }



        //Referencia aos produtos do pedido
        //Referencia para que eu consiga cadastrar um pedido com os produtos
        [BsonElement("productId")]
        [JsonIgnore] //Ignorando o Id para que nao duplique ao mostrar o codigo
        public List<string>? ProductId { get; set; } //Retorna como lista de string pois sera varios produtos

        //referencia para que quando eu liste os produtos, venha os dados de cada produto(Lista)
        public List<Product>? Products { get; set; }





        //Referencia ao cliente que esta fazendo o pedido
        //Referencia para que quando eu consiga cadastrar um pedido com o cliente
        [BsonElement("clientId")]
        [JsonIgnore] //Ignorando o Id para que nao duplique ao mostrar o codigo
        public string? ClientId { get; set; } //Retorna apenas como string e nao como lista, pois sera apenas 1 cliente por Ordem
        //Referencia para que quando eu liste os pedidos, venham os dados do cliente
        public Client? Client { get; set; }



        //Adicionando atributos adicionais, caso necessario.
        public Dictionary<string, string> AdditionalAttributes { get; set; }

        public Order()
        {
            AdditionalAttributes = new Dictionary<string, string>();
        }


    }
}