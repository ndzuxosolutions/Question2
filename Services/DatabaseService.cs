using Question2.Database;
using Question2.Services.Interfaces;

namespace Question2.Services
{
    public class DatabaseService : IDatabaseService
    {
        private readonly SageModel _sageModel;
        private readonly ILogger<DatabaseService> _logger;

        public DatabaseService(SageModel sageModel, ILogger<DatabaseService> logger)
        {
            _sageModel = sageModel;
            _logger = logger;
        }

        public async Task<List<SP_GetRecentOrders>> GetRecentOrders()
        {
            try
            {
                var orders = _sageModel.GetRecentOrders();
                return await Task.FromResult(orders.ToList());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving recent order details from database.");
                throw;
            }
        }
    }
}
