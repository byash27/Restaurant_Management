using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MyRestaurant.Web.Models
{
    [Table(name: "Orders")]
    public partial class Order
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Order ID")]
        public int OrderId { get; set; }

        [Required]
        [Display(Name = "Order Date")]
        public System.DateTime OrderDate { get; set; }

        [Required]
        [DefaultValue(1)]
        public int Quantity { get; set; }


        #region

        virtual public int CustomerId { get; set; }
        [ForeignKey(nameof(Order.CustomerId))]
        public Customer Customer { get; set; }

        virtual public int CategoryId { get; set; }
        [ForeignKey(nameof(Order.CategoryId))]
        public Category Category { get; set; }

        virtual public int ItemId { get; set; }
        [ForeignKey(nameof(Order.ItemId))]
        public Item Item { get; set; }

        #endregion


    }
}
