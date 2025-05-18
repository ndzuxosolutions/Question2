using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Question2.Database;

public partial class Product
{
    [Key]
    public int ProductID { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string ProductName { get; set; } = null!;

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
