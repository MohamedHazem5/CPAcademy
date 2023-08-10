namespace CPAcademy.DataAccess.Repository.IRepository
{
    public class EnrollRepository : Repository<Enroll>, IEnrollRepository
    {
        public EnrollRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}