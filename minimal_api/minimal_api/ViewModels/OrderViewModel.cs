using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace minimal_api.Domains
{
    public class OrderViewModel
    {

        [BsonId]
        //define o nome do campo no MongoDB como "_id" e o tipo como "ObjectId"
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("date")]
        public DateTime Date = DateTime.Now;

        [BsonElement("status")]
        public string? Status { get; set; }

        [BsonElement("products")]
        [BsonIgnore]
        [JsonIgnore]
        public List<Product>? Products { get; set; }

        [BsonElement("productId")]
        public List<string>? ProductId { get; set; }

        [BsonElement("clientId")]
        public string? ClientId { get; set; }

        [BsonIgnore]
        [JsonIgnore]
        public Client? Client { get; set; }



    }
}