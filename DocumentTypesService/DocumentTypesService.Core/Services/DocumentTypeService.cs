using DocumentTypesService.Core.Entities;
using DocumentTypesService.Core.Interfaces;

namespace DocumentTypesService.Core.Services
{
    public class DocumentTypeService : IDocumentTypeService
    {
        private readonly IDocumentTypeRepository _documentTypeRepository;

        public DocumentTypeService(IDocumentTypeRepository documentTypeRepository)
        {
            _documentTypeRepository = documentTypeRepository;
        }

        public async Task<List<DocumentType>> GetAllDocumentTypes()
        {
            return await _documentTypeRepository.GetDocumentTypesAsync();
        }

        public async Task<DocumentType> GetDocumentType(string id)
        {
            return await _documentTypeRepository.GetDocumentTypeAsync(id);
        }

        public async Task InsertDocumentType(DocumentType documentType)
        {
            await _documentTypeRepository.CreateDocumentTypeAsync(documentType);
        }

        public async Task UpdateDocumentType(string id, DocumentType documentType)
        {
            await _documentTypeRepository.UpdateDocumentTypeAsync(id, documentType);
        }

        public async Task DeleteDocumentType(string id)
        {
            await _documentTypeRepository.RemoveDocumentTypeAsync(id);
        }
    }
}
