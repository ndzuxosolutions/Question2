using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Question2.Database;

public partial class Customer
{
    [Key]
    public int CustomerID { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string CustomerName { get; set; } = null!;

    [InverseProperty("Customer")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
