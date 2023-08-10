namespace CPAcademy.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IArticleRepository ArticleRepository { get; }
        IBlogRepository BlogRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        ICertificateRepository CertificateRepository{ get; }
        IChoiceRepository ChoiceRepository { get; }
        IContentRepository ContentRepository { get; }
        ICourseRepository CourseRepository { get; }
        IDiscussionRepository DiscussionRepository { get; }
        IEnrollRepository EnrollRepository { get; }
        IEventRepository EventRepository { get; }
        IInterestRepository InterestRepository{ get; }
        ILearnerInterestRepository LearnerInterestRepository{ get; }
        ILectuteRepository LectuteRepository { get; }
        IMailRepository MailRepository { get; }
        INewsRepository NewsRepository { get; }
        INoteRepository NoteRepository { get; }
        IProgressRepository ProgressRepository { get; }
        IQuestionRepository QuestionRepository { get; }
        IQuizRepository QuizRepository { get; }
        IReviewRepository ReviewRepository { get; }
        ISectionRepository SectionRepository { get; }
        ISkillCourseRepository SkillCourseRepository { get; }
        ISkillRepository SkillRepository { get; }
        ISubscriptionRepository SubscriptionRepository { get; }
        ITopicRepository TopicRepository { get; }
        IUserRepository UserRepository { get; }
        IVideoRepository VideoRepository { get; }

        Task<int> Save();
        
    }
}