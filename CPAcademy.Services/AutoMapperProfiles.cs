﻿namespace CPAcademy.Services
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
            CreateMap<Review, ReviewDto>().ReverseMap();
            CreateMap<Enroll, EnrollDto>().ReverseMap();



            CreateMap<Course, CoursePostDto>()
            .ReverseMap()
            .ForMember(dest => dest.Id, src => src.Ignore())
            .ForMember(dest => dest.Topic, src => src.Ignore())
            .ForMember(dest => dest.Category, src => src.Ignore())
            .ForMember(dest => dest.Instructor, src => src.Ignore())
            .ForMember(dest => dest.Enrolls, src => src.Ignore())
            .ForMember(dest => dest.Reviews, src => src.Ignore())
            .ForMember(dest => dest.Skills, src => src.Ignore())
            .ForMember(dest => dest.Duration, src => src.Ignore())
            .ForMember(dest => dest.Certificates, src => src.Ignore());


            CreateMap<Section, SectionPostDto>()
            .ReverseMap()
            .ForMember(dest => dest.Lectures, src => src.Ignore())
            .ForMember(dest => dest.Course, src => src.Ignore())
            .ForMember(dest => dest.Id, src => src.Ignore());

            CreateMap<Lecture, LecturePostDto>()
            .ForMember(dest => dest.Time, src => src.Ignore())
            .ReverseMap()
            .ForMember(dest => dest.CDate, src => src.Ignore())
            .ForMember(dest => dest.Progresses, src => src.Ignore())
            .ForMember(dest => dest.Discussions, src => src.Ignore())
            .ForMember(dest => dest.Notes, src => src.Ignore())
            .ForMember(dest => dest.Section, src => src.Ignore())
            .ForMember(dest => dest.Id, src => src.Ignore());

            CreateMap<Lecture, LecturePutDto>()
            .ReverseMap()
            .ForMember(dest => dest.CDate, src => src.Ignore())
            .ForMember(dest => dest.Progresses, src => src.Ignore())
            .ForMember(dest => dest.Discussions, src => src.Ignore())
            .ForMember(dest => dest.Notes, src => src.Ignore())
            .ForMember(dest => dest.Section, src => src.Ignore());

            CreateMap<Video, VideoPutDto>()
            .ReverseMap()
            .ForMember(dest => dest.Lecture, src => src.Ignore());

            CreateMap<Video, VideoPostDto>()
            .ReverseMap()
            .ForMember(dest => dest.Id, src => src.Ignore())
            .ForMember(dest => dest.Lecture, src => src.Ignore());

            CreateMap<Article, ArticlePutDto>()
           .ReverseMap()
           .ForMember(dest => dest.Lecture, src => src.Ignore());

            CreateMap<Article, ArticlePostDto>()
            .ReverseMap()
            .ForMember(dest => dest.Id, src => src.Ignore())
            .ForMember(dest => dest.Lecture, src => src.Ignore());


            CreateMap<Question, QuestionPostDto>()
            .ReverseMap()
            .ForMember(dest => dest.Id, src => src.Ignore())
            .ForMember(dest => dest.Choices, src => src.Ignore())
            .ForMember(dest => dest.Quiz, src => src.Ignore());

            CreateMap<Question, QuestionPutDto>()
            .ReverseMap()
            .ForMember(dest => dest.Choices, src => src.Ignore())
            .ForMember(dest => dest.Quiz, src => src.Ignore());

            CreateMap<Choice, ChoicePostDto>()
            .ReverseMap()
            .ForMember(dest => dest.Id, src => src.Ignore())
            .ForMember(dest => dest.Question, src => src.Ignore());

            CreateMap<Choice, ChoicePutDto>()
            .ReverseMap()
            .ForMember(dest => dest.Question, src => src.Ignore());

        }
    }

}
