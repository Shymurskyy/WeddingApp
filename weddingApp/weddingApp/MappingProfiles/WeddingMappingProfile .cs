using AutoMapper;
using weddingApp.Model.DTO_s;
using weddingApp.Model;
using weddingApp.Model.Entities;

namespace weddingApp.MappingProfiles
{
    public class WeddingMappingProfile : Profile
    {
        public WeddingMappingProfile()
        {
            CreateMap<Couple, CoupleDto>();
            CreateMap<Gift, GiftDto>();
            CreateMap<Guest, GuestDto>();
            CreateMap<Service, ServiceDto>();
            CreateMap<Thing, ThingDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<WeddingEvent, WeddingEventDto>();
            CreateMap<WeddingService, WeddingServiceDto>();
        }
    }
}