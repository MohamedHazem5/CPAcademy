namespace CPAcademy.DataAccess.Repository.IRepository
{
    public class LectureRepository : Repository<Lecture>, ILectureRepository
    {
        public LectureRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}