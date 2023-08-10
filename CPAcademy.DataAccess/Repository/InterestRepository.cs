namespace CPAcademy.DataAccess.Repository.IRepository
{
    public class InterestRepository : Repository<Interest>, IInterestRepository
    {
        public InterestRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}