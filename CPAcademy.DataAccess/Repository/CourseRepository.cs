using CPAcademy.Models.DTOs;

namespace CPAcademy.DataAccess.Repository.IRepository
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(ApplicationDbContext context) : base(context)
        {
        }

        public double AvrageRate(int courseId)
        {
            var course = _context.Courses.Where(c => c.Id == courseId).Include(c => c.Reviews).FirstOrDefault();
            if (course.Reviews.Count == 0)
                return 0;
            return course.Reviews.Sum(c => c.Rate) / course.Reviews.Count;

        }
        public void AvrageRate(IEnumerable<CourseDto> coursesDto)
        {
            foreach (var courseDto in coursesDto)
            {
                var course = _context.Courses.Where(c => c.Id == courseDto.Id).Include(c => c.Reviews).FirstOrDefault();
                if (course.Reviews.Count != 0)
                    courseDto.AvgRate = course.Reviews.Sum(c => c.Rate) / course.Reviews.Count;
            }
        }
        // public void NumberOfLectures(IEnumerable<CourseDto> coursesDto)
        // {
        //     foreach (var courseDto in coursesDto)
        //     {
        //         var course = _context.Courses.Where(c => c.Id == courseDto.Id).Include(c => c.Sections).FirstOrDefault();
        //         foreach(var section in course.Sections)
        //         {
        //             courseDto.NumberOfLecture += _context.Lectures.Count(l => l.SectionId == section.SectionId);
        //         }
        //     }
        // }
    }
}