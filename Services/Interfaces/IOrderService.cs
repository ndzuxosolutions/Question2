using Question2.Models;

namespace Question2.Services.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderDetailDTO>> GetRecentOrderDetails();
    }
}
