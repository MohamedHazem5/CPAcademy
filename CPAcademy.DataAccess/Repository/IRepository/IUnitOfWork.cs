namespace CPAcademy.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IArticleRepository Article { get; }
        IBlogRepository Blog { get; }
        ICategoryRepository Category { get; }
        ICertificateRepository Certificate{ get; }
        IChoiceRepository Choice { get; }
        IContentRepository Content { get; }
        ICourseRepository Course { get; }
        IDiscussionRepository Discussion { get; }
        IEnrollRepository Enroll { get; }
        IEventRepository Event { get; }
        IInterestRepository Interest{ get; }
        ILearnerInterestRepository LearnerInterest{ get; }
        ILectureRepository Lecture { get; }
        IMailRepository Mail { get; }
        INewsRepository News { get; }
        INoteRepository Note { get; }
        IProgressRepository Progress { get; }
        IQuestionRepository Question { get; }
        IQuizRepository Quiz { get; }
        IReviewRepository Review { get; }
        ISectionRepository Section { get; }
        ISkillCourseRepository SkillCourse { get; }
        ISkillRepository Skill { get; }
        ISubscriptionRepository Subscription { get; }
        ITopicRepository Topic { get; }
        IUserRepository User { get; }
        IVideoRepository Video { get; }
        IOrderRepository Order { get; }

        Task<int> Save();
        
    }
}