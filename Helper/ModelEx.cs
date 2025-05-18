using Question2.Database;
using Question2.Models;

namespace Question2.Helper
{
    public static class ModelEx
    {
        public static void SetValuesFrom(this OrderDetailDTO target, SP_GetRecentOrders order)
        {
            target.OrderID = order.OrderID;
            target.CustomerName = order.CustomerName;
            target.ProductName = order.ProductName;
            target.QuantityOrdered = order.QuantityOrdered;
            target.OrderDate = order.OrderDate;
            target.ProductPrice = order.ProductPrice;
            target.TotalPrice = order.TotalPrice;
        }
    }
}
