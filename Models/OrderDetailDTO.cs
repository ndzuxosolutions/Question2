namespace Question2.Models
{
    public class OrderDetailDTO
    {
        public int OrderID { get; set; }
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public int QuantityOrdered { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
