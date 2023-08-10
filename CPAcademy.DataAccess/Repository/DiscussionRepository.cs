namespace CPAcademy.DataAccess.Repository.IRepository
{
    public class DiscussionRepository : Repository<Discussion>, IDiscussionRepository
    {
        public DiscussionRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}