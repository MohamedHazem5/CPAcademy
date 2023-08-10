namespace CPAcademy.DataAccess.Repository.IRepository
{
    public class ContentRepository : Repository<Content>, IContentRepository
    {
        public ContentRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}