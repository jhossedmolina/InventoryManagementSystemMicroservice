using AutoMapper;
using DocumentTypesService.Core.DTOs;
using DocumentTypesService.Core.Entities;
using DocumentTypesService.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocumentTypesService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentTypeController : ControllerBase
    {
        private readonly IDocumentTypeService _documentTypeService;
        private readonly IMapper _mapper;

        public DocumentTypeController(IDocumentTypeService documentTypeService, IMapper mapper)
        {
            _documentTypeService = documentTypeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllDocumentTypes()
        {
            var documentTypes = await _documentTypeService.GetAllDocumentTypes();
            var documentTypesDto = _mapper.Map<List<DocumentTypeDto>>(documentTypes);
            return Ok(documentTypesDto);
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult> GetDocumentTypeById(string id)
        {
            var documentType = await _documentTypeService.GetDocumentType(id);
            var documentTypeDto = _mapper.Map<DocumentTypeDto>(documentType);

            if(documentTypeDto is null)
                return NotFound();

            return Ok(documentTypeDto);
        }

        [HttpPost]
        public async Task<ActionResult> InsertDocumentType(DocumentTypeDto documentTypeDto)
        {
            var documentType = _mapper.Map<DocumentType>(documentTypeDto);
            await _documentTypeService.InsertDocumentType(documentType);
            documentTypeDto = _mapper.Map<DocumentTypeDto>(documentType);
            return CreatedAtAction(nameof(GetDocumentTypeById), new { id = documentTypeDto.Id }, documentTypeDto);
        }

        [HttpPut("{id:length(24)}")]   
        public async Task<ActionResult> UpdateDocumentType(string id, DocumentTypeDto documentTypeDto)
        {
            var currentDocumentType = await _documentTypeService.GetDocumentType(id);
            if (currentDocumentType is null)
                return NotFound();

            documentTypeDto.Id = currentDocumentType.Id;

            var documentType = _mapper.Map<DocumentType>(documentTypeDto);
            await _documentTypeService.UpdateDocumentType(id, documentType);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<ActionResult> DeleteDocumentType(string id)
        {
            var documentType = await _documentTypeService.GetDocumentType(id);

            if(documentType is null)
                return NotFound();

            await _documentTypeService.DeleteDocumentType(id);

            return NoContent();
        }

    }
}
