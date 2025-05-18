using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Question2.Database;

public partial class Order
{
    [Key]
    public int OrderID { get; set; }

    public int CustomerID { get; set; }

    public DateOnly OrderDate { get; set; }

    [ForeignKey("CustomerID")]
    [InverseProperty("Orders")]
    public virtual Customer Customer { get; set; } = null!;

    [InverseProperty("Order")]
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
