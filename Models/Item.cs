using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MyRestaurant.Web.Models
{
    [Table(name: "Items")]
    public partial class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Item ID")]
        public int ItemId { get; set; }

        [Required]
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }

        [Required]
        [Display(Name = "Item Price")]
        public decimal ItemPrice { get; set; }

        #region

        public ICollection<Order> Orders { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }

        #endregion
    }
}
