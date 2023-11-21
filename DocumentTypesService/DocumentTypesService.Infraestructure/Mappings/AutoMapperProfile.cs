using AutoMapper;
using DocumentTypesService.Core.DTOs;
using DocumentTypesService.Core.Entities;

namespace DocumentTypesService.Infraestructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<DocumentType, DocumentTypeDto>();
            CreateMap<DocumentTypeDto, DocumentType>();
        }
    }
}
