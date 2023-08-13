using AutoMapper;
using CPAcademy.Models;
using CPAcademy.Models.DTOs;

namespace CPAcademy.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegisterDto, User>().ForMember(dis => dis.EXP,src=>src.Ignore())
                .ForMember(dis => dis.EXP, src => src.Ignore())
                .ForMember(dis => dis.Bio, src => src.Ignore())
                .ForMember(dis => dis.PhoneNumber, src => src.Ignore())
                .ForMember(dis => dis.ImgURL, src => src.Ignore())
                .ForMember(dis => dis.CDate, src => src.Ignore())
                
                .ReverseMap()
                ;
        }
    }
}
