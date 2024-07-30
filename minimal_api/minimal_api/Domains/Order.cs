using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

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
        public string? Status {  get; set; }

        //[BsonElement("product")]
        //public Product? Product { get; set; }

        //[BsonElement("client")]
        //public Client? Client { get; set; }

        public Dictionary<string, string> AdditionalAttributes { get; set; }

        public Order()
        {
            AdditionalAttributes = new Dictionary<string, string>();
        }
    }
}