using AutoMapper;
using CPAcademy.Models;
using CPAcademy.Models.DTOs;

namespace CPAcademy.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<Course, CourseDto>()
            .ReverseMap()
            .ForMember(dest => dest.TopicId, src => src.Ignore())
            .ForMember(dest => dest.CategoryId, src => src.Ignore())
            .ForMember(dest => dest.InstructorId, src => src.Ignore())
            .ForMember(dest => dest.Enrolls, src => src.Ignore())
            .ForMember(dest => dest.Reviews, src => src.Ignore())
            .ForMember(dest => dest.Certificates, src => src.Ignore());

            
        }
    }
}
