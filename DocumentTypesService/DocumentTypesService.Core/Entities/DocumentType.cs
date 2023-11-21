using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DocumentTypesService.Core.Entities
{
    public class DocumentType
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("code")]
        public string Code { get; set; } = null!;

        [BsonElement("name")]
        public string Name { get; set; } = null!;
    }
}
