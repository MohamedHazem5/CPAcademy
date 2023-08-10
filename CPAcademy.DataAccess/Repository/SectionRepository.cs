namespace CPAcademy.DataAccess.Repository.IRepository
{
    public class SectionRepository : Repository<Section>, ISectionRepository
    {
        public SectionRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}