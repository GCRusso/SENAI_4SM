using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace minimal_api.Domains
{
    public class Product
    {
        [BsonId]//define que esta prop é Id do objeto
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)] // Define o nome do campo no MongoDb como "_id" e o tipo como "ObjectedId"
        public string? Id { get; set; }

        [BsonElement("name")]
        public string? Name { get; set; }

        [BsonElement("price")]
        public decimal Price { get; set; }

        //Adiciona um dicionario para atributos adicionais, caso nao adicione este dicionario nao seria possivel adicionar um novo atributo pelo BD
        public Dictionary<string, string> AdditionalAttributes { get; set; }
        /// <summary>
        /// Ao ser instanciado um obj da classe Product, o atributo `AdditionalAttributes`
        /// ja vira com um novo dicionario e portanto habilitado para adicionar + atributos
        /// </summary>
        public Product() {
            AdditionalAttributes = new Dictionary<string, string>();
        }
    }
}
