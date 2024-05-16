using time_of_your_life.Models.DTO;
using time_of_your_life.Models;
using AutoMapper;

namespace time_of_your_life.Map
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ClockProps, CreateClockPropsDTO>();
            CreateMap<ClockProps, UpdateClockPropsDTO>();
            CreateMap<CreateClockPropsDTO, ClockProps>();
            CreateMap<UpdateClockPropsDTO, ClockProps>();
        }
    }
}
