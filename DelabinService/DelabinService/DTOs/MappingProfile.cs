using AutoMapper;
using DelabinService.Models;

namespace DelabinService.DTOs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Document, DocumentDto>();
            CreateMap<DocData, DataDto>();
            CreateMap<CreateDocumentDto, Document>();
            CreateMap<UpdateDocumentDto, Document>();
        }
    }
}
