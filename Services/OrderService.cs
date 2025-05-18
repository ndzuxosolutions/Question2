using Question2.Helper;
using Question2.Models;
using Question2.Services.Interfaces;

namespace Question2.Services
{
    public class OrderService : IOrderService
    {
        private readonly IDatabaseService _databaseService;
        private readonly ILogger<OrderService> _logger;

        public OrderService(IDatabaseService databaseService, ILogger<OrderService> logger)
        {
            _databaseService = databaseService;
            _logger = logger;
        }

        public async Task<List<OrderDetailDTO>> GetRecentOrderDetails()
        {
            try
            {
                _logger.LogInformation("Retrieving order details for the past 30 days");
                var recentOrders = await _databaseService.GetRecentOrders();
                var orderDetailDtos = new List<OrderDetailDTO>();

                foreach (var order in recentOrders)
                {
                    var orderDetailDto = new OrderDetailDTO();
                    orderDetailDto.SetValuesFrom(order);
                    orderDetailDtos.Add(orderDetailDto);
                }

                return orderDetailDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving recent order details");
                throw; 
            }
        }
    }
}
