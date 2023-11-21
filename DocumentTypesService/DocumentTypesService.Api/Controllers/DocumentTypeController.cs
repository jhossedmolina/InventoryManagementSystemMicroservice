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
        private readonly IDocumentTypeRepository _documentTypeRepository;
        private readonly IMapper _mapper;

        public DocumentTypeController(IDocumentTypeRepository documentTypeRepository, IMapper mapper)
        {
            _documentTypeRepository = documentTypeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllDocumentTypes()
        {
            var documentTypes = await _documentTypeRepository.GetDocumentTypesAsync();
            var documentTypesDto = _mapper.Map<List<DocumentTypeDto>>(documentTypes);
            return Ok(documentTypesDto);
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult> GetDocumentTypeById(string id)
        {
            var documentType = await _documentTypeRepository.GetDocumentTypeAsync(id);
            var documentTypeDto = _mapper.Map<DocumentTypeDto>(documentType);

            if(documentTypeDto is null)
                return NotFound();

            return Ok(documentTypeDto);
        }

        [HttpPost]
        public async Task<ActionResult> InsertDocumentType(DocumentTypeDto documentTypeDto)
        {
            var documentType = _mapper.Map<DocumentType>(documentTypeDto);
            await _documentTypeRepository.CreateDocumentTypeAsync(documentType);
            documentTypeDto = _mapper.Map<DocumentTypeDto>(documentType);
            return CreatedAtAction(nameof(GetDocumentTypeById), new { id = documentTypeDto.Id }, documentTypeDto);
        }

        [HttpPut("{id:length(24)}")]   
        public async Task<ActionResult> UpdateDocumentType(string id, DocumentTypeDto documentTypeDto)
        {
            var currentDocumentType = await _documentTypeRepository.GetDocumentTypeAsync(id);
            if (currentDocumentType is null)
                return NotFound();

            documentTypeDto.Id = currentDocumentType.Id;

            var documentType = _mapper.Map<DocumentType>(documentTypeDto);
            await _documentTypeRepository.UpdateDocumentTypeAsync(id, documentType);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<ActionResult> DeleteDocumentType(string id)
        {
            var documentType = await _documentTypeRepository.GetDocumentTypeAsync(id);

            if(documentType is null)
                return NotFound();

            await _documentTypeRepository.RemoveDocumentTypeAsync(id);

            return NoContent();
        }

    }
}
