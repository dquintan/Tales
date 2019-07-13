using AutoMapper;
using Pasajes.Api.Entities;
using Pasajes.Api.Models;

namespace Pasajes.Api.Profiles
{
    public class TaleSourceProfile : Profile
    {
        public TaleSourceProfile()
        {
            CreateMap<TaleSource, TaleSourceDto>();
            CreateMap<TaleSourceDto, TaleSource>();
        }
    }
}
