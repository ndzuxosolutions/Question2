using Question2.Database;

namespace Question2.Services.Interfaces
{
    public interface IDatabaseService
    {
        Task<List<SP_GetRecentOrders>> GetRecentOrders();
    }
}
