using CPAcademy.Models.DTOs;

namespace CPAcademy.DataAccess.Repository.IRepository
{
    public interface IEnrollRepository : IRepository<Enroll>
    {
        Task<Enroll> CreateOrder(EnrollDto orderDto);
    }
}