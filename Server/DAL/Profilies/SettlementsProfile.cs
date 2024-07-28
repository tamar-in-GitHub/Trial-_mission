using AutoMapper;
using Project.Models;
using DAL.DTO;

namespace DAL.Profiles
{
    public class SettlementsProfile : Profile
    {
        public SettlementsProfile()
        {
            CreateMap<Settlements, SettlementsDto>();
            CreateMap<SettlementsDto, Settlements>();
        }
    }
}
