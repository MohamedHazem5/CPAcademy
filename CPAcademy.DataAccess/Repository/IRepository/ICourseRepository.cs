using CPAcademy.Models.DTOs;

namespace CPAcademy.DataAccess.Repository.IRepository
{
    public interface ICourseRepository : IRepository<Course>
    {
        double AvrageRate(int courseId);
        void AvrageRate(IEnumerable<CourseDto> coursesDto);
    }
}