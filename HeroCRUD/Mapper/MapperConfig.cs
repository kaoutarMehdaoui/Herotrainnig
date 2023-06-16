
using AutoMapper;
using Domain.Models;
using HeroCRUD.ModelDTO;

namespace HeroCRUD.Mapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
           CreateMap<HeroDTO,Heros>().ReverseMap();
            CreateMap<PowerDTO,Powers>().ReverseMap();
        }
    }
}
