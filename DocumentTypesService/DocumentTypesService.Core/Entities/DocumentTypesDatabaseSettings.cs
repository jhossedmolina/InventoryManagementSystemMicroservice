namespace DocumentTypesService.Core.Entities
{
    public class DocumentTypesDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string DocumentTypesCollectionName { get; set; } = null!;
    }
}
