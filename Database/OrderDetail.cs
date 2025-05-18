using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Question2.Database;

[PrimaryKey("OrderID", "ProductID")]
public partial class OrderDetail
{
    [Key]
    public int OrderID { get; set; }

    [Key]
    public int ProductID { get; set; }

    public int Quantity { get; set; }

    [ForeignKey("OrderID")]
    [InverseProperty("OrderDetails")]
    public virtual Order Order { get; set; } = null!;

    [ForeignKey("ProductID")]
    [InverseProperty("OrderDetails")]
    public virtual Product Product { get; set; } = null!;
}
