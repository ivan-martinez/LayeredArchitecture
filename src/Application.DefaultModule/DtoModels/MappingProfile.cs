using AutoMapper;
using Domain.DefaultModule.Entities.Models;

namespace Application.DefaultModule.DtoModels
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add map for each object you want AutoMAP
            CreateMap<TableDefault, TableDefaultDto>();
        }
    }
}
