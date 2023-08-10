namespace CPAcademy.DataAccess.Repository.IRepository
{
    public class TopicRepository : Repository<Topic>, ITopicRepository
    {
        public TopicRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}