namespace CPAcademy.DataAccess.Repository.IRepository
{
    public class SkillCourseRepository : Repository<SkillCourse>, ISkillCourseRepository
    {
        public SkillCourseRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}