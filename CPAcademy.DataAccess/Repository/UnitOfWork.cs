using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPAcademy.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IArticleRepository Article { get; private set; }
        public IBlogRepository Blog { get; private set; }
        public ICategoryRepository Category { get; private set; }
        public ICertificateRepository Certificate { get; private set; }
        public IChoiceRepository Choice { get; private set; }
        public IContentRepository Content { get; private set; }
        public ICourseRepository Course { get; private set; }
        public IDiscussionRepository Discussion { get; private set; }
        public IEnrollRepository Enroll { get; private set; }
        public IEventRepository Event { get; private set; }
        public IInterestRepository Interest { get; private set; }
        public ILearnerInterestRepository LearnerInterest { get; private set; }
        public ILectuteRepository Lectute { get; private set; }
        public IMailRepository Mail { get; private set; }
        public INewsRepository News { get; private set; }
        public INoteRepository Note { get; private set; }
        public IProgressRepository Progress { get; private set; }
        public IQuestionRepository Question { get; private set; }
        public IQuizRepository Quiz { get; private set; }
        public IReviewRepository Review { get; private set; }
        public ISectionRepository Section { get; private set; }
        public ISkillCourseRepository SkillCourse { get; private set; }
        public ISkillRepository Skill { get; private set; }
        public ISubscriptionRepository Subscription { get; private set; }
        public ITopicRepository Topic { get; private set; }
        public IUserRepository User { get; private set; }
        public IVideoRepository Video { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Article = new ArticleRepository(_context);
            Blog = new BlogRepository(_context);
            Category = new CategoryRepository(_context);
            Certificate = new CertificateRepository(_context);
            Choice = new ChoiceRepository(_context);
            Content = new ContentRepository(_context);
            Course = new CourseRepository(_context);
            Discussion = new DiscussionRepository(_context);
            Enroll = new EnrollRepository(_context);
            Event = new EventRepository(_context);
            Interest = new InterestRepository(_context);
            LearnerInterest = new LearnerInterestRepository(_context);
            Lectute = new LectuteRepository(_context);
            Mail = new MailRepository(_context);
            News = new NewsRepository(_context);
            Note = new NoteRepository(_context);
            Progress = new ProgressRepository(_context);
            Question = new QuestionRepository(_context);
            Quiz = new QuizRepository(_context);
            Review = new ReviewRepository(_context);
            Section = new SectionRepository(_context);
            SkillCourse = new SkillCourseRepository(_context);
            Skill = new SkillRepository(_context);
            Subscription = new SubscriptionRepository(_context);
            Topic = new TopicRepository(_context);
            User = new UserRepository(_context);
            Video = new VideoRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}