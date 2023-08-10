namespace CPAcademy.DataAccess.Repository.IRepository
{
    public class LectuteRepository : Repository<Lecture>, ILectuteRepository
    {
        public LectuteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}