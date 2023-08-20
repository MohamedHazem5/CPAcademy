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
        public async Task<Enroll> CreateOrder(EnrollDto orderDto)
        {


            var order = new Enroll
            {
                LearnerId = orderDto.LearnerId,
                Price = orderDto.Price,
                CourseId = orderDto.CourseId,
            };

            await _context.Enrolls.AddAsync(order);
            await _context.SaveChangesAsync();

            return order;

        }
    }
}