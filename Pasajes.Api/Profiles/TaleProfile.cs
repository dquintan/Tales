using AutoMapper;
using Pasajes.Api.Entities;
using Pasajes.Api.Models;

namespace Pasajes.Api.Profiles
{
    public class TaleProfile : Profile
    {
        public TaleProfile()
        {
            CreateMap<Tale, TaleCreationDto>();
            CreateMap<TaleCreationDto, Tale>();
        }
    }
}
