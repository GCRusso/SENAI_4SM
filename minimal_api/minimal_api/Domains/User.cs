﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace minimal_api.Domains
{
    public class User
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string? Name { get; set; }

        [BsonElement("email")]
        public string? Email { get; set; }

        [BsonElement("password")]
        public string? Password { get; set; }

        //Adiciona um dicionario para atributos adicionais, caso nao adicione este dicionario nao seria possivel adicionar um novo atributo pelo BD
        public Dictionary<string, string> AdditionalAttributes { get; set; }

        public User()
        {
            AdditionalAttributes = new Dictionary<string, string>();
        }
    }
}