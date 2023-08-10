namespace CPAcademy.DataAccess.Repository.IRepository
{
    public class LearnerInterestRepository : Repository<LearnerInterest>, ILearnerInterestRepository
    {
        public LearnerInterestRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}