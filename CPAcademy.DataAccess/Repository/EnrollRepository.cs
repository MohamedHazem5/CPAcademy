using CPAcademy.Models.DTOs;

namespace CPAcademy.DataAccess.Repository.IRepository
{
    public class EnrollRepository : Repository<Enroll>, IEnrollRepository
    {
        private readonly ApplicationDbContext _context;
        public EnrollRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<bool> CheckCourse(int courseId, int userId)
        {
            var result = await _context.Enrolls.FirstOrDefaultAsync(x => x.CourseId == courseId && x.LearnerId == userId);

            if (result == null)
            {
                return false;
            }
            return true;
        }


    }
}