namespace CPAcademy.DataAccess.Repository.IRepository
{
    public class ProgressRepository : Repository<Progress>, IProgressRepository
    {
        public ProgressRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}