using CPAcademy.Models.DTO;


namespace CPAcademy.DataAccess.Repository.IRepository
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order> CreateOrder(OrderDto orderDto);
    }
}