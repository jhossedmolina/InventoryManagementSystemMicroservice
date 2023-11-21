using DocumentTypesService.Core.Entities;

namespace DocumentTypesService.Core.Interfaces
{
    public interface IDocumentTypeRepository
    {
        Task<List<DocumentType>> GetDocumentTypesAsync();

        Task<DocumentType?> GetDocumentTypeAsync(string id);

        Task CreateDocumentTypeAsync(DocumentType documentType);

        Task UpdateDocumentTypeAsync(string id, DocumentType documentType);

        Task RemoveDocumentTypeAsync(string id);
    }
}
