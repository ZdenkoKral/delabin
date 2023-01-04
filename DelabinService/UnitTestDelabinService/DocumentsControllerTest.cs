using AutoMapper;
using DelabinService.Contracts.Interfaces;
using DelabinService.Controllers;
using DelabinService.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using System.Net;

namespace UnitTestDelabinService
{
    public class DocumentsControllerTest : ControllerBase
    {
        private readonly DocumentsController _controller;
        private static IMapper? _mapper;

        public DocumentsControllerTest()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
            
            var mockRepo = new Mock<IRepositoryWrapper>();
            mockRepo.Setup(r => r.DocumentsRepository.GetDocumentWithDetails(Guid.Parse("00000000-0000-0000-0000-000000000000")));
           
            _controller = new DocumentsController(mockRepo.Object, _mapper);
        }

        [Fact]
        public async Task Test_GetAllDocumentsAsync()
        {
            // Act
            var result = await _controller.GetAllDocuments();
            var okResult = result as OkObjectResult;

            // assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task GetById_UnknownGuidPassed_ReturnsNotFoundResultAsync()
        {
            // Act
            var notFoundResult =await _controller.GetDocumentWithDetails(Guid.NewGuid());
            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
        }

        [Fact]
        public async Task Add_InvalidObjectPassed_ReturnsBadRequestAsync()
        {
            // Arrange
            var nameMissingItem = new CreateDocumentDto()
            { 

            };
            _controller.ModelState.AddModelError("tags", "Required");
            // Act
            var badResponse = await _controller.CreateDocument(nameMissingItem);
            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }

        [Fact]
        public async Task Add_ValidObjectPassed_ReturnsCreatedResponseAsync()
        {
            // Arrange
            CreateDocumentDto testItem = new CreateDocumentDto()
            {
                tags = "test",
            };
            // Act
            var createdResponse = await _controller.CreateDocument(testItem) as CreatedAtRouteResult;
            // 
            var item = createdResponse.Value as DocumentDto;
            // Assert
            Assert.IsType<DocumentDto>(item);
            Assert.Equal("test", item.tags);
        }

        [Fact]
        public async Task Remove_NotExistingGuidPassed_ReturnsNotFoundResponseAsync()
        {
            // Arrange
            var notExistingGuid = Guid.NewGuid();
            // Act
            var badResponse = await _controller.DeleteDocument(notExistingGuid);
            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }
    }
}