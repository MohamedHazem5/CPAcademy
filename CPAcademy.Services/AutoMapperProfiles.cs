namespace CPAcademy.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<Course, CourseDto>()
            .ForMember(dest => dest.AvgRate, src => src.Ignore())
            .ForMember(dest => dest.NumberOfLecture, src => src.Ignore())
            .ReverseMap()
            .ForMember(dest => dest.Skills, src => src.Ignore())
            .ForMember(dest => dest.TopicId, src => src.Ignore())
            .ForMember(dest => dest.CategoryId, src => src.Ignore())
            .ForMember(dest => dest.InstructorId, src => src.Ignore())
            .ForMember(dest => dest.Enrolls, src => src.Ignore())
            .ForMember(dest => dest.Reviews, src => src.Ignore())
            .ForMember(dest => dest.Certificates, src => src.Ignore());



            CreateMap<Blog, BlogDto>().ReverseMap();
            CreateMap<Event, EventDto>().ReverseMap();


            CreateMap<Course, CoursePostDto>()
            .ReverseMap()
            .ForMember(dest => dest.Id, src => src.Ignore())
            .ForMember(dest => dest.Topic, src => src.Ignore())
            .ForMember(dest => dest.Category, src => src.Ignore())
            .ForMember(dest => dest.Instructor, src => src.Ignore())
            .ForMember(dest => dest.Enrolls, src => src.Ignore())
            .ForMember(dest => dest.Reviews, src => src.Ignore())
            .ForMember(dest => dest.Skills, src => src.Ignore())
            .ForMember(dest => dest.Certificates, src => src.Ignore());


            CreateMap<Section, SectionPostDto>()
            .ReverseMap()
            .ForMember(dest => dest.Lectures, src => src.Ignore())
            .ForMember(dest => dest.Course, src => src.Ignore())
            .ForMember(dest => dest.Id, src => src.Ignore());
        }
    }
}
