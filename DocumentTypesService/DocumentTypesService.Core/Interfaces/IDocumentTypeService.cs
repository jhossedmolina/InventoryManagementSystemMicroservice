using DocumentTypesService.Core.Entities;

namespace DocumentTypesService.Core.Interfaces
{
    public interface IDocumentTypeService
    {
        Task<List<DocumentType>> GetAllDocumentTypes();

        Task<DocumentType> GetDocumentType(string id);

        Task InsertDocumentType(DocumentType documentType);

        Task UpdateDocumentType(string id, DocumentType documentType);

        Task DeleteDocumentType(string id);
    }
}
