using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Core.Models;

public class Order
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OrderID { get; set; }

    [ForeignKey("Customer")]
    [Required]
    public int CustomerID { get; set; }
    public Customer? Customer { get; set; }

    public List<Book>? Books { get; set; }
}