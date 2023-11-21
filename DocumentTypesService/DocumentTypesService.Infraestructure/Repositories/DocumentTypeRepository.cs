using DocumentTypesService.Core.Entities;
using DocumentTypesService.Core.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DocumentTypesService.Infraestructure.Repositories
{
    public class DocumentTypeRepository : IDocumentTypeRepository
    {
        private readonly IMongoCollection<DocumentType> _documentTypesCollection;

        public DocumentTypeRepository(IOptions<DocumentTypesDatabaseSettings> documentTypesDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                documentTypesDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                documentTypesDatabaseSettings.Value.DatabaseName);

            _documentTypesCollection = mongoDatabase.GetCollection<DocumentType>(
                documentTypesDatabaseSettings.Value.DocumentTypesCollectionName);
        }

        public async Task<List<DocumentType>> GetDocumentTypesAsync() => 
            await _documentTypesCollection.Find(_ => true).ToListAsync();

        public async Task<DocumentType?> GetDocumentTypeAsync(string id) => 
            await _documentTypesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateDocumentTypeAsync(DocumentType documentType) => 
            await _documentTypesCollection.InsertOneAsync(documentType);

        public async Task UpdateDocumentTypeAsync(string id, DocumentType documentType) =>
            await _documentTypesCollection.ReplaceOneAsync(x => x.Id == id, documentType);

        public async Task RemoveDocumentTypeAsync(string id) =>
            await _documentTypesCollection.DeleteOneAsync(x => x.Id == id);
    }
}
