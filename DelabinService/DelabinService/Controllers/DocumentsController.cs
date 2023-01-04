using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DelabinService.Data;
using DelabinService.Models;
using DelabinService.Contracts.Interfaces;
using AutoMapper;
using DelabinService.DTOs;

namespace DelabinService.Controllers
{
    [Route("documents")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private IMapper _mapper;

        public DocumentsController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDocuments()
        {
            try
            {
                var documents = await _repository.DocumentsRepository.GetAllDocuments();
                var documentResult = _mapper.Map<IEnumerable<DocumentDto>>(documents);
                return Ok(documentResult);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "GetDocument")]
        public async Task<IActionResult> GetDocumentWithDetails(Guid id)
        {
            try
            {
                var document = await _repository.DocumentsRepository.GetDocumentWithDetails(id);
                if (document == null)
                {
                    return NotFound();
                }
                else
                {
                    var documentResult = _mapper.Map<DocumentDto>(document);
                    return Ok(documentResult);
                }
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateDocument([FromBody] CreateDocumentDto document)
        {
            try
            {
                if (document is null)
                {
                    return BadRequest("Document object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var documentEntity = _mapper.Map<Document>(document);
                _repository.DocumentsRepository.CreateDocument(documentEntity);
                await _repository.SaveAsync();
                var createdDocument = _mapper.Map<DocumentDto>(documentEntity);
                return CreatedAtRoute("GetDocument", new { id = createdDocument.id }, createdDocument);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.ToString());
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDocument(Guid id, [FromBody] UpdateDocumentDto document)
        {
            try
            {
                if (document is null)
                {
                    return BadRequest("Document object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var documentEntity = await _repository.DocumentsRepository.GetDocumentWithDetails(id);
                if (documentEntity is null)
                {
                    return NotFound();
                }
                _mapper.Map(document, documentEntity);
                _repository.DocumentsRepository.UpdateDocument(documentEntity);
                await _repository.SaveAsync();
                return NoContent();
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocument(Guid id)
        {
            try
            {
                var document = await _repository.DocumentsRepository.GetDocumentWithDetails(id);
                if (document == null)
                {
                    return NotFound();
                }
                if (_repository.DataRepository.DataByDocument(id).Any())
                {
                    return BadRequest("Cannot delete Document. It has related Data. Delete those Data first");
                }

                _repository.DocumentsRepository.DeleteDocument(document);
                await _repository.SaveAsync();
                return NoContent();
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
