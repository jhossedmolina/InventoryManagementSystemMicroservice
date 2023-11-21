using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DocumentTypesService.Core.DTOs
{
    public class DocumentTypeDto
    {
        public string? Id { get; set; }

        public string Code { get; set; } = null!;

        public string Name { get; set; } = null!;
    }
}
