using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPAcademy.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IArticleRepository ArticleRepository { get; private set; }
        public IBlogRepository BlogRepository { get; private set; }
        public ICategoryRepository CategoryRepository { get; private set; }
        public ICertificateRepository CertificateRepository { get; private set; }
        public IChoiceRepository ChoiceRepository { get; private set; }
        public IContentRepository ContentRepository { get; private set; }
        public ICourseRepository CourseRepository { get; private set; }
        public IDiscussionRepository DiscussionRepository { get; private set; }
        public IEnrollRepository EnrollRepository { get; private set; }
        public IEventRepository EventRepository { get; private set; }
        public IInterestRepository InterestRepository { get; private set; }
        public ILearnerInterestRepository LearnerInterestRepository { get; private set; }
        public ILectuteRepository LectuteRepository { get; private set; }
        public IMailRepository MailRepository { get; private set; }
        public INewsRepository NewsRepository { get; private set; }
        public INoteRepository NoteRepository { get; private set; }
        public IProgressRepository ProgressRepository { get; private set; }
        public IQuestionRepository QuestionRepository { get; private set; }
        public IQuizRepository QuizRepository { get; private set; }
        public IReviewRepository ReviewRepository { get; private set; }
        public ISectionRepository SectionRepository { get; private set; }
        public ISkillCourseRepository SkillCourseRepository { get; private set; }
        public ISkillRepository SkillRepository { get; private set; }
        public ISubscriptionRepository SubscriptionRepository { get; private set; }
        public ITopicRepository TopicRepository { get; private set; }
        public IUserRepository UserRepository { get; private set; }
        public IVideoRepository VideoRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            ArticleRepository = new ArticleRepository(_context);
            BlogRepository = new BlogRepository(_context);
            CategoryRepository = new CategoryRepository(_context);
            CertificateRepository = new CertificateRepository(_context);
            ChoiceRepository = new ChoiceRepository(_context);
            ContentRepository = new ContentRepository(_context);
            CourseRepository = new CourseRepository(_context);
            DiscussionRepository = new DiscussionRepository(_context);
            EnrollRepository = new EnrollRepository(_context);
            EventRepository = new EventRepository(_context);
            InterestRepository = new InterestRepository(_context);
            LearnerInterestRepository = new LearnerInterestRepository(_context);
            LectuteRepository = new LectuteRepository(_context);
            MailRepository = new MailRepository(_context);
            NewsRepository = new NewsRepository(_context);
            NoteRepository = new NoteRepository(_context);
            ProgressRepository = new ProgressRepository(_context);
            QuestionRepository = new QuestionRepository(_context);
            QuizRepository = new QuizRepository(_context);
            ReviewRepository = new ReviewRepository(_context);
            SectionRepository = new SectionRepository(_context);
            SkillCourseRepository = new SkillCourseRepository(_context);
            SkillRepository = new SkillRepository(_context);
            SubscriptionRepository = new SubscriptionRepository(_context);
            TopicRepository = new TopicRepository(_context);
            UserRepository = new UserRepository(_context);
            VideoRepository = new VideoRepository(_context);
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