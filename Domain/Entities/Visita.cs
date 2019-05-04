using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RomanosApi.Domain.Entities
{
    public class Visita
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Consultor { get; set; }
        public BsonDateTime Data { get; set; }
        public string TipoVisita { get; set; }
        public string TipoCliente { get; set; }
        public string StatusCliente { get; set; }
        public int __v { get; set; }

    }
}
