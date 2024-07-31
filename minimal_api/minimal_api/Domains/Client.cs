using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace minimal_api.Domains
{
    public class Client
    {
        [BsonId]
        [BsonElement("_id"),BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("UserId")]
        public string? UserId { get; set; }

        [BsonElement("cpf")]
        public double?  Cpf { get; set; }

        [BsonElement("phone")]
        public double? Phone { get; set; }

        [BsonElement("address")]
        public string? Address { get; set; }

        [JsonIgnore]
        public User? user { get; set; }

        public Dictionary<string, string> AdditionalAttributes { get; set; }

        public Client()
        {
            AdditionalAttributes = new Dictionary<string, string>();
        }
    }
}
